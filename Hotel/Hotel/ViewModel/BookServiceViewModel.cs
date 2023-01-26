using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class BookServiceViewModel : BaseViewModel
    {
        private int id;
        private ObservableCollection<ServiceVM> listSV;

        public ObservableCollection<ServiceVM> ListSV
        {
            get { return listSV; }
            set { listSV = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ServiceVM> listSVBook;

        public ObservableCollection<ServiceVM> ListSVBook
        {
            get { return listSVBook; }
            set { listSVBook = value; OnPropertyChanged(); }
        }
        public ICommand Load { get; set; }
        public ICommand AddSV { get; set; }
        public ICommand RemoveSV { get; set; }
        public ICommand Cancel { get; set; }
        public ICommand Book { get; set; }
        public BookServiceViewModel()
        {
            Load = new RelayCommand<BookService>((p) => true, (p) => { id = Convert.ToInt32(p.idbook.Text); });
            AddSV = new RelayCommand<object>((p) => true, (p) => addsv(p));
            RemoveSV = new RelayCommand<object>((p) => true, (p) => removesv(p));
            Cancel = new RelayCommand<BookService>((p) => true, (p) => cancel(p));
            Book = new RelayCommand<BookService>((p) => true, (p) => book(p));

            ListSVBook = new ObservableCollection<ServiceVM>();
            loaddbSv();
        }
        private void addsv(object p)
        {
            ServiceVM ser = (ServiceVM)p;
            ListSVBook.Add(ser);
            ListSV.Remove(ser);
        }
        private void removesv(object p)
        {
            ServiceVM ser = (ServiceVM)p;
            ListSVBook.Remove(ser);
            loaddbSv();
        }
        private void cancel(BookService p)
        {
            p.Close();
        }
        private void book(BookService p)
        {
            try
            {
                foreach (var i in ListSVBook)
                    if (i.NumSer <= 0)
                        throw new Exception("Chưa nhập số lượng của dịch vụ!");
                using (var db = new QLYHOTELEntities())
                {
                    foreach (var i in ListSVBook)
                    {
                        CUNGCAP c = new CUNGCAP();
                        c.MANV = 1; // ??
                        c.MADV = Convert.ToInt32(i.ID);
                        c.MADAT = id;
                        c.SOLUONG = i.NumSer;
                        c.TONGTIEN = i.NumSer * i.Price;
                        db.CUNGCAPs.Add(c);
                        db.SaveChanges();
                    }
                }
                new DialogCustomize("Thành công!").ShowDialog();
                ListSVBook.Clear();
                loaddbSv();
            }
            catch (Exception ex)
            {
                new DialogCustomize(ex.Message).ShowDialog();
            }
        }
        private void loaddbSv()
        {
            ListSV = new ObservableCollection<ServiceVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.DICHVUs select s;
                foreach (var p in select)
                {
                    bool ok = true;

                    foreach (var bok in ListSVBook)
                        if (bok.ID == p.MADV.ToString())
                        {
                            ok = false;
                            break;
                        }
                    if (ok)
                        ListSV.Add(new ServiceVM() { ID = p.MADV.ToString(), Name = p.TENDV, Price = (int)p.DONGIA });
                }
            }
        }
    }
}
