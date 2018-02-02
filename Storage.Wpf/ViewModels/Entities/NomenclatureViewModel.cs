using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class NomenclatureViewModel : EntityViewModel<Nomenclature>
    {
        #region Properties

        public override string Title => Nomenclature.ToString();

        public Nomenclature Nomenclature => Entity as Nomenclature;

        [Column("Код", Width = 50)]
        public int Code
        {
            get { return Nomenclature.Code; }
            set
            {
                if (Nomenclature.Code != value)
                {
                    Nomenclature.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        [Column("Код внешн. системы")]
        public string ExternalCode
        {
            get { return Nomenclature.ExternalCode; }
            set
            {
                if (Nomenclature.ExternalCode != value)
                {
                    Nomenclature.ExternalCode = value;
                    OnPropertyChanged("ExternalCode");
                }
            }
        }

        [Column("Активна")]
        public bool Active
        {
            get { return Nomenclature.Active; }
            set
            {
                if (Nomenclature.Active != value)
                {
                    Nomenclature.Active = value;
                    OnPropertyChanged("Active");
                }
            }
        }

        [Column("Порода", Position = 0)]
        public Species Species
        {
            get { return Nomenclature.Species; }
            set
            {
                if (Nomenclature.Species == null || !Nomenclature.Species.Equals(value))
                {
                    Nomenclature.Species = value;
                    OnPropertyChanged("Species");
                }
            }

        }

        [Column("Вид продукции", Position = 1)]
        public TypeProd TypeProd
        {
            get { return Nomenclature.TypeProd; }
            set
            {
                if (Nomenclature.TypeProd == null || !Nomenclature.TypeProd.Equals(value))
                {
                    Nomenclature.TypeProd = value;
                    OnPropertyChanged("TypeProd");
                }
            }
        }

        [Column("Сорт", Position = 2)]
        public Grade Grade
        {
            get { return Nomenclature.Grade; }
            set
            {
                if (Nomenclature.Grade == null || !Nomenclature.Grade.Equals(value))
                {
                    Nomenclature.Grade = value;
                    OnPropertyChanged("Grade");
                }
            }
        }

        public int Request
        {
            get { return Nomenclature.Request; }
            set
            {
                if (Nomenclature.Request != value)
                {
                    Nomenclature.Request = value;
                    OnPropertyChanged("Request");
                }
            }
        }

        public int Height
        {
            get { return Nomenclature.Height; }
            set
            {
                if (Nomenclature.Height != value)
                {
                    Nomenclature.Height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        public int Width
        {
            get { return Nomenclature.Width; }
            set
            {
                if (Nomenclature.Width != value)
                {
                    Nomenclature.Width = value;
                    OnPropertyChanged("Width");
                }
            }
        }

        public int Wethness
        {
            get { return Nomenclature.Wethness; }
            set
            {
                if (Nomenclature.Wethness != value)
                {
                    Nomenclature.Wethness = value;
                    OnPropertyChanged("Wethness");
                }
            }
        }

        #region List

        private IEnumerable<Species> speciesList;

        public IEnumerable<Species> SpeciesList
        {
            get
            {
                if (speciesList == null)
                    speciesList = (new Repository<Species>()).ReadList();

                return speciesList;
            }
        }

        private IEnumerable<TypeProd> typeProdList;

        public IEnumerable<TypeProd> TypeProdList
        {
            get
            {
                if (typeProdList == null)
                    typeProdList = (new Repository<TypeProd>()).ReadList();

                return typeProdList;
            }
        }


        private IEnumerable<Grade> gradeList;
        public IEnumerable<Grade> GradeList
        {
            get
            {
                if (gradeList == null)
                    gradeList = (new Repository<Grade>()).ReadList();

                return gradeList;
            }
        }


        #endregion

        #endregion

        #region MyRegion

        #endregion
    }
}
