using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Data;
using System.Collections;
using System.ComponentModel;

namespace Bja.Soporte.Paginacion
{

    public class Paginacion //: CollectionView
    {
        //private readonly IList _innerList;
        private Int64 _itemsPerPage;
        private Int64 _totalCount;
        private Int64 _totalFound;
        private string _paginationTextFormat;

        private Int64 _currentPage = 1;

        //public Paginacion(IList innerList, int itemsPerPage)
        //    : base(innerList)
        //{
        //    this._innerList = innerList;
        //    this._itemsPerPage = itemsPerPage;
        //}

        public Paginacion()
        {
        }

        public Paginacion(Int64 totalCount, Int64 totalFound, int itemsPerPage)
        {
            InitPagination(totalCount, totalFound, itemsPerPage);
        }

        public void InitPagination(Int64 totalCount, Int64 totalFound, int itemsPerPage)
        {
            this._currentPage = 1;
            this._itemsPerPage = itemsPerPage;
            this._totalCount = totalCount;
            this._totalFound = totalFound;
        }

        public Int64 totalEncontrados
        {
            get { return _totalFound; }
            set { _totalFound = value; }
        }
        

        public Int64 itemsPorPagina //overrride
        {
            get { return this._itemsPerPage; }
        }

        //public Int64 ItemsPerPage { get { return this._itemsPerPage; } }

        public Int64 paginaActual
        {
            get { return this._currentPage; }
            set
            {
                this._currentPage = value;
                //this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public Int64 numeroPaginas
        {
            get 
            {
                return (this._totalFound + this._itemsPerPage - 1) 
                    / this._itemsPerPage; 
            }
        }

        public Int64 EndIndex
        {
            get
            {
                var end = this._currentPage * this._itemsPerPage - 1;
                return (end > this._totalFound) ? this._totalFound : end;
            }
        }

        public Int64 StartIndex
        {
            get { return (this._currentPage - 1) * this._itemsPerPage; }
        }

        public Int64 TotalRecords 
        { 
            get { return this._totalCount; }
            set { this._totalCount = value; }
        }
    
        //public override object GetItemAt(int index)
        //{
        //    var offset = index % (this._itemsPerPage); 
        //    return this._innerList[this.StartIndex + offset];
        //}

        public void MoveToNextPage()
        {
            if (this._currentPage < this.numeroPaginas)
            {
                this.paginaActual += 1;
            }
            //this.Refresh();
        }

        public void MoveToPreviousPage()
        {
            if (this._currentPage > 1)
            {
                this.paginaActual -= 1;
            }
            //this.Refresh();
        }

        public void MoveToFirstPage()
        {
            this.paginaActual = 1;
        }

        public void MoveToLastPage()
        {
            this._currentPage = this.numeroPaginas;
        }

        /// <summary>
        /// Set the pagination format text
        /// "Page {current_page} of {total_pages} ({page_start_record} - {page_end_record} of {total_records})"
        /// </summary>
        /// <param name="paginationTextFormat"></param>
        public void setPaginationTextFormat(string paginationTextFormat)
        {
            this._paginationTextFormat = paginationTextFormat;
        }

        /// <summary>
        /// Get the pagination text in base to the specified text format
        /// </summary>
        /// <returns>The formated text</returns>
        public string getPaginationText()
        {
            string newTextFormat = this._paginationTextFormat;

            newTextFormat = newTextFormat.Replace("{current_page}", this.paginaActual.ToString());
            newTextFormat = newTextFormat.Replace("{total_pages}", this.numeroPaginas.ToString());
            newTextFormat = newTextFormat.Replace("{page_start_record}", this.StartIndex.ToString());
            newTextFormat = newTextFormat.Replace("{page_end_record}", this.EndIndex.ToString());
            newTextFormat = newTextFormat.Replace("{total_records}", this.TotalRecords.ToString());

            return newTextFormat;
        }
    }
}

