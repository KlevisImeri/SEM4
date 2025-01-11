//=============================================================================================
// Computer Graphics Sample Program: Pixel-driven 2D graphics
//=============================================================================================
#include "framework.h"
#include <iostream>
#include <list>

float random() { return (float)rand() / RAND_MAX; }

struct Object {
	vec4 color;
	virtual bool In(vec2 r) = 0; // containment test
};

struct Circle : public Object {
	vec2 center;  // center
	float R; 	   // radius
	bool In(vec2 r) { return (dot(r - center, r - center) - R * R < 0); }
	Circle(vec2 _center, float _R, vec4 _color) { center = _center; R = _R; color = _color; }
};

struct HalfPlane : public Object {
	vec2 r0, n; // position vec, normal vec
	bool In(vec2 r) { return (dot(r - r0, n) < 0); }
	HalfPlane(vec2 _r0, vec2 _n, vec4 _color) { r0 = _r0; n = _n; color = _color; }
};

struct GeneralEllipse : public Object {
	vec2 f1, f2; 
	float C;
	bool In(vec2 r) { return (length(r - f1) + length(r - f2) < C); }
	GeneralEllipse(vec2 _f1, vec2 _f2, float _C, vec4 _color) { f1 = _f1; f2 = _f2; C = _C; color = _color; }
};

struct Parabola : public Object {
	vec2 f, r0, n; // f = focus, (r0,n) = directrix line
	bool In(vec2 r) { return (fabs(dot(r - r0, n)) > length(r - f)); }
	Parabola(vec2 _f, vec2 _r0, vec4 _color) { f = _f; r0 = _r0; n = normalize(f - r0); color = _color; }
};

const float worldRadius = 10;

// 2D camera
class Camera2D {
	vec2 wCenter, wSize;     // camera center, width and height in world coordinates
	vec2 pLeftBottom, pSize; // viewport left-bottom corner, width and height in pixel coordinates
public:
	Camera2D() : wCenter(0, 0), wSize(2 * worldRadius, 2 * worldRadius), pLeftBottom(0, 0), pSize(windowWidth, windowHeight) { }

	vec2 Viewport2Window(int pX, int pY) {
		float cX = (pX + 0.5f - pLeftBottom.x - pSize.x / 2) / pSize.x * 2;
		float cY = (pY + 0.5f - pLeftBottom.y - pSize.y / 2) / pSize.y * 2;
		return (vec2(cX, cY) * wSize * 0.5 + wCenter);
	}
	void Zoom(float s) { wSize = wSize * s; }
	void Pan(vec2 t) { wCenter = wCenter + t; }
};

Camera2D camera;

class Scene {              // virtual world
	std::list<Object *> objs;    // objects with decreasing priority
	Object * picked = nullptr;	// currently selected
public:
	void Add(Object * o) { objs.push_front(o); picked = o; }
	void Pick(int pX, int pY) {
		vec2 wPoint = camera.Viewport2Window(pX, pY);
		picked = nullptr;
		for (auto o : objs) {
			if (o->In(wPoint)) { picked = o; return; }
		}
	}
	void Del() {
		if (picked) {
			objs.erase(std::find(objs.begin(), objs.end(), picked));
			delete picked;
			picked = nullptr;
		}
	}
	void BringToFront() {
		if (picked) {
			objs.erase(std::find(objs.begin(), objs.end(), picked));
			objs.push_front(picked);
		}
	}
	void BringToBack() {
		if (picked) {
			objs.erase(std::find(objs.begin(), objs.end(), picked));
			objs.push_back(picked);
		}
	}
	void Render(std::vector<vec4>& image) {
		for (int pX = 0; pX < windowWidth; pX++) for (int pY = 0; pY < windowHeight; pY++) {
			vec2 wPoint = camera.Viewport2Window(pX, pY);
			for (auto o : objs) {
				if (o->In(wPoint)) {
					image[pY * windowWidth + pX] = (o != picked) ? o->color : vec4(0, 0, 0, 1);
					break;
				}
			}
		}
	}
	void Build() {
		Add(new HalfPlane(vec2(-6, -7), vec2(2, -4), vec4(1, 1, 0, 1)));
		Add(new Parabola(vec2(-1, -3), vec2(-3, -4), vec4(0, 0, 1, 1)));
		Add(new GeneralEllipse(vec2(-4, -2), vec2(2, 3), 10, vec4(1, 0, 0, 1)));
		Add(new Circle(vec2(3, 3), 4, vec4(0, 1, 0, 1)));
		for (int i = 0; i < 1000; i++) {
			vec2 center = (vec2(random(), random()) * 2 - vec2(1, 1)) * worldRadius;
			Add(new Circle(center, 0.2, vec4(random() + 0.1f, random() + 0.1f, random() + 0.1f, 1)));
		}
	}
};
	
GPUProgram gpuProgram; // vertex and fragment shaders
Scene scene;

// vertex shader in GLSL
const char *vertexSource = R"(
	#version 330
    precision highp float;

	layout(location = 0) in vec2 cVertexPosition;	// Attrib Array 0
	out vec2 texcoord;

	void main() {
		texcoord = (cVertexPosition + vec2(1, 1))/2;							// -1,1 to 0,1
		gl_Position = vec4(cVertexPosition.x, cVertexPosition.y, 0, 1); 		// transform to clipping space
	}
)";

// fragment shader in GLSL
const char *fragmentSource = R"(
	#version 330
    precision highp float;

	uniform sampler2D textureUnit;
	in  vec2 texcoord;			// interpolated texture coordinates
	out vec4 fragmentColor;		// output that goes to the raster memory as told by glBindFragDataLocation

	void main() {
		fragmentColor = texture(textureUnit, texcoord); 
	}
)";

class FullScreenTexturedQuad {
	unsigned int vao, vbo;	// vertex array object id and texture id
	Texture * pTexture;
public:
	FullScreenTexturedQuad(std::vector<vec4>& image) {
		glGenVertexArrays(1, &vao);	// create 1 vertex array object
		glBindVertexArray(vao);		// make it active

		glGenBuffers(1, &vbo);	// Generate 1 vertex buffer objects

		// vertex coordinates: vbo0 -> Attrib Array 0 -> vertexPosition of the vertex shader
		glBindBuffer(GL_ARRAY_BUFFER, vbo); // make it active, it is an array
		float vertexCoords[] = { -1, -1,  1, -1,  1, 1,  -1, 1 };	// two triangles forming a quad
		glBufferData(GL_ARRAY_BUFFER, sizeof(vertexCoords), vertexCoords, GL_STATIC_DRAW);	   // copy to that part of the memory which is not modified 
		glEnableVertexAttribArray(0);
		glVertexAttribPointer(0, 2, GL_FLOAT, GL_FALSE, 0, NULL);     // stride and offset: it is tightly packed

		pTexture = new Texture(windowWidth, windowHeight, image);
	}

	void Draw() {
		glBindVertexArray(vao);	// make the vao and its vbos active playing the role of the data source
		pTexture->SetUniform(gpuProgram.getId(), "textureUnit");
		glDrawArrays(GL_TRIANGLE_FAN, 0, 4);	// draw two triangles forming a quad
	}
	~FullScreenTexturedQuad() {
		glDeleteBuffers(1, &vbo);
		glDeleteVertexArrays(1, &vao);
	}
};

// Initialization, create an OpenGL context
void onInitialization() {
	glViewport(0, 0, windowWidth, windowHeight);
	scene.Build();
	// create program for the GPU
	gpuProgram.Create(vertexSource, fragmentSource, "fragmentColor");
}

// Window has become invalid: Redraw
void onDisplay() {
	std::vector<vec4> image(windowWidth * windowHeight, vec4(0.6, 0.6, 0.6, 1));
	scene.Render(image);
	FullScreenTexturedQuad fullScreenTexturedQuad(image);
	fullScreenTexturedQuad.Draw();
	glutSwapBuffers();									// exchange the two buffers
}

// Key of ASCII code pressed
void onKeyboard(unsigned char key, int pX, int pY) {
	switch (key) {
	case 'd': scene.Del(); break;
	case 'f': scene.BringToFront(); break;
	case 'b': scene.BringToBack(); break;
	case 'z': camera.Zoom(0.9); break;
	case 'Z': camera.Zoom(1.1); break;
	case 'a': camera.Pan(vec2(-0.1 * worldRadius, 0)); break;
	case 's': camera.Pan(vec2(0.1 * worldRadius, 0)); break;
	case 'w': camera.Pan(vec2(0, -0.1 * worldRadius)); break;
	case 'x': camera.Pan(vec2(0, -0.1 * worldRadius)); break;
	}
	glutPostRedisplay();
}

// Key of ASCII code released
void onKeyboardUp(unsigned char key, int pX, int pY) {

}

// Mouse click event
void onMouse(int button, int state, int pX, int pY) {
	if (state == GLUT_DOWN) {
		scene.Pick(pX, windowHeight - pY);
		glutPostRedisplay();
	}
}

// Move mouse with key pressed
void onMouseMotion(int pX, int pY) {
}

// Idle event indicating that some time elapsed: do animation here
void onIdle() {
}
