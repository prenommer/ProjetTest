using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Prenommer
{

    public class Class1
    {

        public void SauveTreeView(TreeView treeView, string filnavn)
        {

            Module1.Bloqué = false;
            Module1.Dialogue = true;

            try
            {

                Module1.Bloqué = true;
                var ListeNoeuds = new ArrayList();  // instanciation de la liste
                var fichier = File.OpenWrite(filnavn);  // Ouverture du fichier en écriture

                var serializer = new BinaryFormatter();  // instanciation du serializeur binaire

                foreach (var noeud in treeView.Nodes)
                    int unused = ListeNoeuds.Add(noeud);

                serializer.Serialize(fichier, ListeNoeuds);
                fichier.Close();
            }

            catch (IOException exc)
            {
                var dialogResult = MessageBox.Show(exc.ToString());
                var dialogResult1 = MessageBox.Show("Stack Trace : " + Constants.vbCrLf + exc.StackTrace);
                throw;
            }

            finally
            {
                var dialogResult1 = MessageBox.Show("L'exécution du processus est terminée.");

            }

        }

        public void ChargeTreeView(TreeView treeView, string filnavn)
        {

            var fichier = File.OpenRead(filnavn); // ouverture du fichier à charger
            var serializer = new BinaryFormatter(); // instanciation du serializeur binaire

            treeView.Nodes.Clear(); // efface tous les noeuds de l'arborescence
            treeView.BeginUpdate(); // à mettre avant l'ajout de beaucoup de noeuds

            ArrayList ListeNoeuds = (ArrayList)serializer.Deserialize(fichier); // Deserialisation dans la liste
            foreach (TreeNode node in ListeNoeuds) // ajout de chaque noeud dans l'arborescence
                int v = treeView.Nodes.Add(node);

            treeView.EndUpdate();
            fichier.Close();

        }

    }
}