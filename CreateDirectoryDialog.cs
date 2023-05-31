#nullable disable
using System;
using System.Windows.Forms;
using System.IO;

public class CreateDirectoryDialog : Form
{
    private TextBox textBox;
    private Button nextButton;
    private Button createButton;
    private Label titleLabel;
    private Label nameLabel;
    private CheckBox htmlCheckBox;
    private CheckBox cssCheckBox;
    private CheckBox jsCheckBox;
    private CheckBox readmeCheckBox;
    private CheckBox imageBankCheckBox;
    private Label frameworkLabel;
    private CheckBox ioniconCheckBox;
    private CheckBox bootstrapCheckBox;

    private bool isFirstPageCompleted = false;

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

        // Créer les checkboxes de la première page
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

        // Créer un bouton suivant pour la première page
        nextButton = new Button { Text = "Suivant", Location = new System.Drawing.Point(15, 280), Width = 100 };
        nextButton.Click += new EventHandler(this.nextButton_Click);
        this.Controls.Add(nextButton);
    }

    private void nextButton_Click(object sender, EventArgs e)
    {
        // Vérifier si la première page est complétée
        if (!isFirstPageCompleted)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("Veuillez entrer un nom de dossier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isFirstPageCompleted = true;

            // Masquer les contrôles de la première page
            titleLabel.Visible = false;
            nameLabel.Visible = false;
            textBox.Visible = false;
            htmlCheckBox.Visible = false;
            cssCheckBox.Visible = false;
            jsCheckBox.Visible = false;
            readmeCheckBox.Visible = false;
            imageBankCheckBox.Visible = false;

            // Afficher les contrôles de la deuxième page
            frameworkLabel = new Label { Text = "Ajout de frameworks et modules", Location = new System.Drawing.Point(15, 50), Width = 360 };
            this.Controls.Add(frameworkLabel);

            ioniconCheckBox = new CheckBox { Text = "Ionicon", Location = new System.Drawing.Point(15, 80), Width = 200 };
            this.Controls.Add(ioniconCheckBox);

            bootstrapCheckBox = new CheckBox { Text = "Bootstrap", Location = new System.Drawing.Point(15, 110), Width = 200 };
            this.Controls.Add(bootstrapCheckBox);

            // Remplacer le texte du bouton suivant par "Créer"
            nextButton.Text = "Créer";
            nextButton.Click -= nextButton_Click; // Supprimer l'ancien gestionnaire d'événement
            nextButton.Click += new EventHandler(this.createButton_Click); // Ajouter un nouveau gestionnaire d'événement
        }
    }

private void createButton_Click(object sender, EventArgs e)
{
    string path = textBox.Text;

    if (!Directory.Exists(path))
    {
        // Créer le dossier
        Directory.CreateDirectory(path);

        // Traiter les options de la première page
        if (htmlCheckBox.Checked)
        {
            // Créer index.html
            File.WriteAllText(Path.Combine(path, "index.html"), "<!DOCTYPE html>\n<html lang=\"fr\">\n<head>\n<meta charset=\"UTF-8\">\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n<title>Document</title>\n</head>\n<body>\n</body>\n</html>");
        }

        if (cssCheckBox.Checked)
        {
            // Créer le dossier style et le fichier style.css
            Directory.CreateDirectory(Path.Combine(path, "style"));
            File.WriteAllText(Path.Combine(path, "style", "style.css"), "/* CSS goes here */");
        }

        if ((htmlCheckBox.Checked) && (cssCheckBox.Checked)) 
        {
            // Ajouter le code CSS à index.html
            string htmlPath = Path.Combine(path, "index.html");
            string cssCode = "<link rel=\"stylesheet\" href=\"style/style.css\">";

            if (File.Exists(htmlPath))
            {
                string htmlContent = File.ReadAllText(htmlPath);
                htmlContent = htmlContent.Replace("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">", "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n" + cssCode);
                File.WriteAllText(htmlPath, htmlContent);
            }
        }

        if (jsCheckBox.Checked)
        {
            // Créer le dossier script et le fichier script.js
            Directory.CreateDirectory(Path.Combine(path, "script"));
            File.WriteAllText(Path.Combine(path, "script", "script.js"), "// JavaScript goes here");
        }

        if ((htmlCheckBox.Checked) && (jsCheckBox.Checked)) 
        {
            // Ajouter le code CSS à index.html
            string htmlPath = Path.Combine(path, "index.html");
            string jsCode = "<script src=\"script/script.js\"></script>";

            if (File.Exists(htmlPath))
            {
                string htmlContent = File.ReadAllText(htmlPath);
                htmlContent = htmlContent.Replace("<body>", "<body>" + jsCode);
                File.WriteAllText(htmlPath, htmlContent);
            }
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

        // Traiter les options de la deuxième page
        if (ioniconCheckBox.Checked)
        {
            // Ajouter le code Ionicon à index.html
            string htmlPath = Path.Combine(path, "index.html");
            string ioniconCode = "<script type=\"module\" src=\"https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.esm.js\"></script>\n" +
                                "<script nomodule src=\"https://unpkg.com/ionicons@7.1.0/dist/ionicons/ionicons.js\"></script>";

            if (File.Exists(htmlPath))
            {
                string htmlContent = File.ReadAllText(htmlPath);
                htmlContent = htmlContent.Replace("</html>", ioniconCode + "\n</html>");
                File.WriteAllText(htmlPath, htmlContent);
            }
        }

        if (bootstrapCheckBox.Checked)
        {
            // Ajouter le code Bootstrap à index.html
            string htmlPath = Path.Combine(path, "index.html");
            string bootstrapCode = "<!-- Latest compiled and minified CSS -->\n" +
                                "<link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css\">\n" +
                                "<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js\"></script>\n" +
                                "<script src=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js\"></script>";

            if (File.Exists(htmlPath))
            {
                string htmlContent = File.ReadAllText(htmlPath);
                htmlContent = htmlContent.Replace("<head>", "<head>\n" + bootstrapCode);
                File.WriteAllText(htmlPath, htmlContent);
            }
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

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new CreateDirectoryDialog());
    }
}
