To solve this program the file menu had each of its event handler functions implemented accordingly. 
The dialog box was simple. The buttons where anchored bottom right and the textbox was pinched horizontally (anchored right and left).
This was an easier part to implement so lets talk about main part.
For the file opener the structure was a split panel where in one was the list view and the other panel had another split panel where in one of the panels was the dialog panel for the name and the creation date while in the other was the multiline textbox.
The fiels that where used to store the current opened file or folder are:
```c
public partial class Form1 : Form
{

	/*--------------------------Fields---------------------------*/
	DirectoryInfo currentDir = null;       //current directory
	FileInfo currentFile = null;           //current laoded file
	int countdown = 100;            //the size of the contdown
	/*--------------------------Fields---------------------------*/
	...
```

Then some helper functions where implemented to make to more easy to structure the code. The `istView1.SelectedItems[0]` used to get the current selected item in the list view. I wont talk long about this because the code is very descriptive. They are described here:
```C
/*--------------------------------------------------Helper fucntions------------------------------------------------------*/
//It loads the the folder and the files from the currentDir
private void loadCurrentFolderInTheList()
{
	listView1.Items.Clear();

	// Load parent directory
	if (currentDir.Parent != null)
	{
		listView1.Items.Add(
			new ListViewItem(
				new string[] { "...", "PAR" }));
	}


	// Load directories
	foreach (DirectoryInfo di in currentDir.GetDirectories())
	{
		listView1.Items.Add(
			new ListViewItem(
				new string[] { di.Name, "DIR" }));
		/*
		 * You can create a recursive funtion to find the directory 
		 * but it just wastes to much resources for no reason
		 */
	}

	// Load files
	foreach (FileInfo fi in currentDir.GetFiles())
	{
		listView1.Items.Add(
			new ListViewItem(
				new string[] { fi.Name, fi.Length.ToString() }));
	}
}

//Loads current file in the details panel.
private void loadCurrentFile()
{
	try
	{
		currentFile = new FileInfo(
			Path.Combine(
				currentDir.FullName, 
				listView1.SelectedItems[0].Text
			)
		);

		lNameText.Text = currentFile.Name;
		lCreatedText.Text = currentFile.CreationTime.ToString();
		multilineTextBox.Text = File.ReadAllText(currentFile.FullName);

	}
	catch { }

}
/*--------------------------------------------------Helper fucntions------------------------------------------------------*/
```
Every time you click in the item in the list view the file name and date of creation should be loaded into the specific labels in the dialog panel and in the content the content of the file should be loaded in the multiline text box. `loadCurrentFile()` takes care of this.

`currentDir` was set in the click of the open menu which created the dialog which askes the user for the directory.
```c
private void miOpen_Click(object sender, EventArgs e)
{
	InputDialog dlg = new InputDialog();
	if (dlg.ShowDialog() == DialogResult.OK)
	{    
		try
		{
			if (!Directory.Exists(dlg.InputText)) return; //You can through and expection if you want
			currentDir = new DirectoryInfo(dlg.InputText);
			loadCurrentFolderInTheList();
		}
		catch { }
	}
}
```
When the open click method is called the new dialog is created. The text from the entered dialog then is turned into the directory. Then the the items form the directory are added.


When an item is clicked upon it is checked that it is a file. If it is a file it id loaded in the details panel.
```C
private void listView1_SelectedIndexChanged(object sender, EventArgs e)
{
	try
	{
		string selectedText = listView1.SelectedItems[0].SubItems[1].Text;
		if (selectedText == "PAR") return;
		if (selectedText == "DIR") return;
		//else
		loadCurrentFile();
	}
	catch { }
}
```

For double clicking the button it is checked what type of item it is. If it is the parent directory then you go to the parent directory and display the files and folders there. If it is a directory inside the directory we are using then we load that directory else we just load the current file. Here is the implementation.
```C
private void listView1_DoubleClick(object sender, EventArgs e)
{
	try
	{ 
		string selectedText = listView1.SelectedItems[0].SubItems[1].Text;

		if (selectedText == "PAR")
		{
			// Navigate back a directory
			DirectoryInfo parentDirectory = currentDir.Parent;
			if (parentDirectory != null)
			{
				currentDir = parentDirectory;
				loadCurrentFolderInTheList(); // Reload the list with the new directory
			}
		}
		else if (selectedText == "DIR")
		{
			// Go inside the directory
			currentDir = new DirectoryInfo(
				Path.Combine(currentDir.FullName, listView1.SelectedItems[0].Text)
			);
			loadCurrentFolderInTheList(); // Reload the list with the new directory
		}
		else
		{
			// Load the current file
			loadCurrentFile();
			reloadTimer.Start();
			countdown = 100;
		}
	}
	catch { }
}
```

The other parts are as mentions in the solutions. Some of the names should be different because I tried to implement everything myself.


