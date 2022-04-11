using MerchantGalaxyWPF.CommonClass;
using MerchantGalaxyWPF.Process;
using MerchantGalaxyWPF.UIClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGalaxyWPF.ViewModel
{
    public class GalaxyViewModel : Telerik.Windows.Controls.ViewModelBase
    {
        public GalaxyViewModel()
        {
            CommonConstant.GetCommonRoman();
            CommonConstant.GetCommonRegex();
            CalculativeList = new ObservableCollection<UIClass.CalcMetals>();
            DeclarativeList = new ObservableCollection<UIClass.DecRomans>();

        }

        #region Properties



        private string inputString;
        public string InputString
        {
            get
            {
                return inputString;
            }

            set
            {
                if (this.inputString != value)
                {
                    this.inputString = value; this.OnPropertyChanged(() => this.InputString);
                }
            }
        }

        private string outputstring;
        public string Outputstring
        {
            get
            {
                return outputstring;
            }

            set
            {
                if (this.outputstring != value)
                {
                    this.outputstring = value; this.OnPropertyChanged(() => this.Outputstring);
                }
            }
        }




        private ObservableCollection<CalcMetals> calculativeList;
        public ObservableCollection<CalcMetals> CalculativeList
        {
            get
            {
                return calculativeList;
            }
            set
            {
                if (this.calculativeList != value)
                {
                    this.calculativeList = value;
                    this.OnPropertyChanged(() => this.CalculativeList);
                }
            }
        }

        private ObservableCollection<DecRomans> declarativeList;
        public ObservableCollection<DecRomans> DeclarativeList
        {
            get
            {
                return declarativeList;
            }
            set
            {
                if (this.declarativeList != value)
                {
                    this.declarativeList = value;
                    this.OnPropertyChanged(() => this.declarativeList);
                }
            }
        }
        #endregion


        #region Methods

        public void Calculation()
        {
            RegexClass Reg = ActionConfig.Instance.GetRegex(InputString);
            if (Reg == null)
            {
                Outputstring = "I have no idea what you are talking about";
                return;
            }
            if (Reg.RegexName == "DECLARATIONQUERY")
            {
                Decleration();
            }
            else if (Reg.RegexName == "CALCULATIVEDECLARATIVEQUERY")
            {
                GetMetal();
            }
            else if (Reg.RegexName == "CREDITQUERY")
            {
                GetHowmany();
            }
            else if (Reg.RegexName == "QUNATITIVEQUERY")
            {
                GetHowmuch();

            }
        }
        public void Decleration()
        {
            DecRomans dec = new UIClass.DecRomans();

            Outputstring = AssignRomans.Instance.Calculation(InputString, ref dec, DeclarativeList.ToList());
            if (dec != null && dec.Values != 0)
            {
                DeclarativeList.Add(dec);
            }
        }

        public void GetMetal()
        {
            CalcMetals calc = new CalcMetals();

            Outputstring = AssignMetals.Instance.Calculation(InputString, DeclarativeList.ToList(), ref calc, CalculativeList.ToList());
            if (calc != null && calc.Credits != 0)
            {
                CalculativeList.Add(calc);
            }
        }

        public void GetHowmuch()
        {
            Outputstring = HowmuchCalculation.Instance.Calculation(InputString, DeclarativeList.ToList());
        }

        public void GetHowmany()
        {
            Outputstring = HowmanyCalculation.Instance.Calculation(InputString, DeclarativeList.ToList(), CalculativeList.ToList());
        }
        #endregion

    }
}
