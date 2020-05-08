﻿#pragma checksum "..\..\..\Controls\DiscreteControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EE838D9BC200C1CB51FC36E098D84EF9C11A465904621B440DC6018BE582F91C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Data_Analysis;
using Data_Analysis.Controls;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Data_Analysis.Controls {
    
    
    /// <summary>
    /// DiscreteControl
    /// </summary>
    public partial class DiscreteControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid discreteGrid;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel calculated;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbAverageValue;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbMode;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbMedian;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbRangeOfVariation;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbMeanLinearDeviation;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDispersion;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbStandardDeviation;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbCoefficientVariation;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbNormalCoefficientAsymmetry;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbEstimationCoefficientAsymmetry;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDegreeAsymmetry;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbMaterialityAsymmetry;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbExcess;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbExcessError;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart polygon;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCalculate;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btR;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogReInit;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btYes;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btNo;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel bgStart;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost dialogError;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbError;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Controls\DiscreteControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOkay;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Data Analysis;component/controls/discretecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\DiscreteControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.discreteGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.calculated = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.tbAverageValue = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbMode = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tbMedian = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.tbRangeOfVariation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tbMeanLinearDeviation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tbDispersion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.tbStandardDeviation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.tbCoefficientVariation = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.tbNormalCoefficientAsymmetry = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.tbEstimationCoefficientAsymmetry = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.tbDegreeAsymmetry = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.tbMaterialityAsymmetry = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.tbExcess = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.tbExcessError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            this.polygon = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 18:
            this.btCalculate = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\Controls\DiscreteControl.xaml"
            this.btCalculate.Click += new System.Windows.RoutedEventHandler(this.btCalculate_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.btR = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\Controls\DiscreteControl.xaml"
            this.btR.Click += new System.Windows.RoutedEventHandler(this.BtR_OnClick);
            
            #line default
            #line hidden
            return;
            case 20:
            this.dialogReInit = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 21:
            this.btYes = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\Controls\DiscreteControl.xaml"
            this.btYes.Click += new System.Windows.RoutedEventHandler(this.btYes_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.btNo = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\Controls\DiscreteControl.xaml"
            this.btNo.Click += new System.Windows.RoutedEventHandler(this.btNo_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            this.bgStart = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 24:
            this.dialogError = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 25:
            this.tbError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 26:
            this.btOkay = ((System.Windows.Controls.Button)(target));
            
            #line 124 "..\..\..\Controls\DiscreteControl.xaml"
            this.btOkay.Click += new System.Windows.RoutedEventHandler(this.btOkay_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

