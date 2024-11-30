using GerenciadorBiblioteca.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorBiblioteca.IClass
{
    public partial class UsuárioForm : Form
    {
        private readonly LibraryController _libraryController;

        public UsuárioForm(LibraryController libraryController)
        {
            InitializeComponent();
            _libraryController = libraryController;
        }

        private void LoadBooks()
        {
            var books = _libraryController.GetBooks();
            dgvBooks.DataSource = books;
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            var selectedBookId = (Guid)dgvBooks.SelectedRows[0].Cells["Id"].Value;
            _libraryController.BorrowBook(selectedBookId);
            LoadBooks();  // Atualiza a lista de livros após emprestar
        }
    }

}
