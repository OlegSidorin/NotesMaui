namespace NotesMaui.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    public string ItemId { set { LoadNote(value); } }
    public NotePage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
        LoadNote(Path.Combine(appDataPath, randomFileName));
	}

    void LoadNote(string fileName)
    {
        Models.Note note = new Models.Note();
        note.Filename = fileName;

        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(fileName);
            note.Text = File.ReadAllText(fileName);
        }

        this.BindingContext = note;
    }

    private async void ButtonSave_Clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Models.Note note)
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
        }

        await Shell.Current.GoToAsync("..");
    }

    private async void ButtonDelete_Clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Models.Note note)
        {
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
        }

        await Shell.Current.GoToAsync("..");
    }
}