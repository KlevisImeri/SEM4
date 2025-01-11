//=============================================================================================
// Parametric curve editor
//=============================================================================================
#include "framework.h"
#include <iostream>
#include <string>

// vertex shader in GLSL
const char * vertexSource = R"(
	#version 330
    precision highp float;

	const float scale = 0.2f;
	uniform float tCurrent;
	layout(location = 0) in float t;	
	out vec3 color;

	void main() {
		color = (t < tCurrent) ? vec3(1, 1, 1) : vec3(0.3, 0.3, 0.3);
		float x = X;
		float y = Y;
		gl_Position = vec4(x * scale, y * scale, 0, 1); // transform to clipping space
	}
)";

// fragment shader in GLSL
const char * fragmentSource = R"(
	#version 330
    precision highp float;

	in vec3 color;
	out vec4 fragmentColor;	// output that goes to the raster memory as told by glBindFragDataLocation

	void main() { fragmentColor = vec4(color, 1); }
)";

class Shader : public GPUProgram {
public:
	Shader() : GPUProgram(false) { }

	bool Edit(std::string Xstring, std::string Ystring) {
		std::string newVertexSource = vertexSource;
		newVertexSource.replace(std::string(newVertexSource).find("X"), 1, Xstring);
		newVertexSource.replace(std::string(newVertexSource).find("Y"), 1, Ystring);
		return create(newVertexSource.c_str(), fragmentSource, "fragmentColor");
	}
};

float tCurrent = 0;	// current clock in sec
const float minParam = -10, maxParam = 10;
const int nTesselatedVertices = 1000;
Shader gpuProgram; // vertex and fragment shaders

class Curve {
	unsigned int vaoCurve, vboCurve;
public:
	Curve() {
		glGenVertexArrays(1, &vaoCurve);
		glBindVertexArray(vaoCurve);
		glGenBuffers(1, &vboCurve);
		glBindBuffer(GL_ARRAY_BUFFER, vboCurve);
		std::vector<float> vertexParams(nTesselatedVertices);
		for (int i = 0; i < nTesselatedVertices; i++) {	// Tessellate
			vertexParams[i] = minParam + (maxParam - minParam) *(float)i / (nTesselatedVertices - 1);
		}
		glBufferData(GL_ARRAY_BUFFER, vertexParams.size() * sizeof(float), &vertexParams[0], GL_STATIC_DRAW);
		glEnableVertexAttribArray(0);
		glVertexAttribPointer(0, 1, GL_FLOAT, GL_FALSE, sizeof(float), NULL); 
	}

	~Curve() { glDeleteBuffers(1, &vboCurve); glDeleteVertexArrays(1, &vaoCurve); }

	void Draw() {
		gpuProgram.setUniform(tCurrent, "tCurrent");
		glDrawArrays(GL_LINE_STRIP, 0, nTesselatedVertices);
	}
};

Curve * curve;

// Window has become invalid: Redraw
void onDisplay() {
	glClearColor(0, 0, 0, 0);							// background color 
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); // clear the screen
	curve->Draw();
	glutSwapBuffers();									// exchange the two buffers
}

// Initialization, create an OpenGL context
void onInitialization() {
	glViewport(0, 0, windowWidth, windowHeight);
	glLineWidth(4.0f);
	curve = new Curve();
}

// Idle event indicating that some time elapsed: do animation here
void onIdle() {
	const long lengthAnimation = maxParam * 1000;
	static long prevTime = 0, endAnimation = lengthAnimation;

	if (prevTime > endAnimation || prevTime == 0) {
		std::string Xstring, Ystring;
		do {
			Xstring = Ystring = "0";
			std::cout << "---------------------------\n";
			std::cout << "x(t) = "; getline(std::cin, Xstring);
			std::cout << "y(t) = "; getline(std::cin, Ystring);
		} while (!gpuProgram.Edit(Xstring, Ystring));
		prevTime = glutGet(GLUT_ELAPSED_TIME); // elapsed time since the start of the program
		tCurrent = minParam;
		endAnimation = prevTime + lengthAnimation;
	}
	else {
		long time = glutGet(GLUT_ELAPSED_TIME); // elapsed time since the start of the program
		tCurrent += (time - prevTime) / 100.0f;				// convert msec to sec
		if (tCurrent > maxParam) tCurrent = minParam;
		prevTime = time;
	}
	glutPostRedisplay();					// redraw the scene
}

void onKeyboard(unsigned char key, int pX, int pY) {} // Key of ASCII code pressed
void onKeyboardUp(unsigned char key, int pX, int pY) {} // Key of ASCII code released
void onMouse(int button, int state, int pX, int pY) {} // Mouse click event
void onMouseMotion(int pX, int pY) {} // Move mouse with key pressed