#nullable disable
using System;
using System.Windows.Forms;
using System.IO;

public class CreateDirectoryDialog : Form
{
    private TextBox textBox;
    private Button submitButton;
    private Button closeButton;
    private Label titleLabel;
    private Label nameLabel;
    private CheckBox htmlCheckBox;
    private CheckBox cssCheckBox;
    private CheckBox jsCheckBox;
    private CheckBox readmeCheckBox;
    private CheckBox imageBankCheckBox;

    public CreateDirectoryDialog()
    {
        Text = "Créateur de dossiers";

        // Ajouter un label pour le titre
        titleLabel = new Label { Text = "Créateur de dossiers", Location = new System.Drawing.Point(15, 15), Width = 360, Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold) };
        this.Controls.Add(titleLabel);

        // Ajouter un label pour le nom du dossier
        nameLabel = new Label { Text = "Comment voulez-vous nommer votre dossier ?", Location = new System.Drawing.Point(15, 50), Width = 360 };
        this.Controls.Add(nameLabel);

        // Créer un TextBox pour saisir le nom du dossier
        textBox = new TextBox { Location = new System.Drawing.Point(15, 80), Width = 250 };
        this.Controls.Add(textBox);

        // Créer les checkboxes
        htmlCheckBox = new CheckBox { Text = "HTML", Location = new System.Drawing.Point(15, 120), Width = 200 };
        cssCheckBox = new CheckBox { Text = "CSS", Location = new System.Drawing.Point(15, 150), Width = 200 };
        jsCheckBox = new CheckBox { Text = "JavaScript", Location = new System.Drawing.Point(15, 180), Width = 200 };
        readmeCheckBox = new CheckBox { Text = "ReadMe", Location = new System.Drawing.Point(15, 210), Width = 200 };
        imageBankCheckBox = new CheckBox { Text = "Banque d'images", Location = new System.Drawing.Point(15, 240), Width = 200 };

        this.Controls.Add(htmlCheckBox);
        this.Controls.Add(cssCheckBox);
        this.Controls.Add(jsCheckBox);
        this.Controls.Add(readmeCheckBox);
        this.Controls.Add(imageBankCheckBox);

        // Créer un bouton de soumission
        submitButton = new Button { Text = "Créer", Location = new System.Drawing.Point(15, 280), Width = 100 };
        submitButton.Click += new EventHandler(this.submitButton_Click);
        this.Controls.Add(submitButton);

        // Créer un bouton de fermeture
        closeButton = new Button { Text = "Fermer", Location = new System.Drawing.Point(120, 280), Width = 100 };
        closeButton.Click += new EventHandler(this.closeButton_Click);
        this.Controls.Add(closeButton);
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        string path = textBox.Text;

        if (!Directory.Exists(path))
        {
            // Créer le dossier
            Directory.CreateDirectory(path);

            if (htmlCheckBox.Checked)
            {
                // Créer index.html
                File.WriteAllText(Path.Combine(path, "index.html"), "<!DOCTYPE html>\n<html>\n</html>");
            }

            if (cssCheckBox.Checked)
            {
                // Créer le dossier style et le fichier style.css
                Directory.CreateDirectory(Path.Combine(path, "style"));
                File.WriteAllText(Path.Combine(path, "style", "style.css"), "/* CSS goes here */");
            }

            if (jsCheckBox.Checked)
            {
                // Créer le dossier script et le fichier script.js
                Directory.CreateDirectory(Path.Combine(path, "script"));
                File.WriteAllText(Path.Combine(path, "script", "script.js"), "// JavaScript goes here");
            }

            if (readmeCheckBox.Checked)
            {
                // Créer le fichier ReadMe.md
                File.WriteAllText(Path.Combine(path, "ReadMe.md"), "Write your ReadMe content here");
            }

            if (imageBankCheckBox.Checked)
            {
                // Créer le dossier bank
                Directory.CreateDirectory(Path.Combine(path, "bank"));
            }

            MessageBox.Show("Dossier créé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Fermer la fenêtre de dialogue
            this.Close();
        }
        else
        {
            MessageBox.Show("Le dossier existe déjà!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        // Fermer la fenêtre de dialogue
        this.Close();
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new CreateDirectoryDialog());
    }
}
