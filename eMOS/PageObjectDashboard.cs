using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace eMOS
{
    class PageObjectDashboard
    {
        public PageObjectDashboard()
        {
            RetryingElementLocator retry = new RetryingElementLocator(Properties.Driver, TimeSpan.FromSeconds(20));

            PageFactory.InitElements(retry.SearchContext, this);
        }

        

        [FindsBy(How = How.XPath, Using = "//a [contains (@href, '/Default')]")]

        public IWebElement DashboardTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id=\'dashboard-list-toggle\']")]

        public IWebElement DashboardDropdown { get; set; }

        public IWebElement SelectDashboard(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//a [contains (text(), '{metricName}')]"));
        }



        [FindsBy(How = How.XPath, Using = "//span[contains (@class,'-plus-sign')]")]

        public IWebElement AddNewWidget { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@ng-model = 'model.title']")]

        public IWebElement DashboardName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@title = \'save changes\']")]

        public IWebElement SaveDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [@class = 'sprite sprite-btn sprite-icon-settings dropdown-toggle']")]

        public IWebElement DashboardGear { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@id = \'dashboard-admin-remove\']")]

        public IWebElement DeleteDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [@id = \'dashboard-admin-edit\']")]

        public IWebElement EditDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//i [@class = \'glyphicon glyphicon-cog\']")]

        public IWebElement ConfigureDashboard { get; set; }




        [FindsBy(How = How.XPath, Using = "//a[text()=\'Metric Detail\']")]

        public IWebElement MetricType { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@type = 'button'] [@ng-disabled = 'ngDisabled']")]

        public IWebElement SelectMetric { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@value = \'Apply\']")]

        public IWebElement ApplySettings { get; set; }

       


        [FindsBy(How = How.XPath, Using = "//select [contains (@ng-model, 'scpType')]")]

        public IWebElement ScpType { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input [contains (@ng-model, 'filter.numberOfPeriods')]")]

        public IWebElement Numberof { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Axis']")]

        public IWebElement Axis { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [contains (@ng-model, 'axisGroup')]")]

        public IWebElement SelectAxis { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [contains (@ng-model, 'axisType')]")]

        public IWebElement AxisType { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [contains (@ng-model, 'yAxisGroup')]")]

        public IWebElement SeriesSelection { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [contains (@ng-model, 'yAxisType')]")]

        public IWebElement SeriesType { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [contains (@ng-model, 'threshold')]")]

        public IWebElement Threshold { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [contains (@ng-model, 'AxisType')]")]

        public IWebElement AverageAxis { get; set; }

        [FindsBy(How = How.XPath, Using = "//conditional-formatting [contains (@class, 'ng-scope')]  //a")]

        public IWebElement AddCondition { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@ng-model = 'conditionalFormat.From']")]

        public IWebElement AddConditionFrom { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@ng-model = 'conditionalFormat.To']")]

        public IWebElement AddConditionTo { get; set; }

        [FindsBy(How = How.XPath, Using = "//div //span [@class = 'ui-select-match-text pull-left']")]

        public IWebElement ColorSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//div [contains (text(), \'#0d6012\')]")]

        public IWebElement SelectColor { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@class = \'all ams-btn ng-binding\']")]

        public IWebElement CheckAll { get; set; }

        [FindsBy(How = How.XPath, Using = "//div [@class = 'form-group col-md-6 conditional-formatting-params'] //input")]

        public IWebElement Base { get; set; }

        [FindsBy(How = How.XPath, Using = "//div [@class = 'form-group col-md-6'] //input")]

        public IWebElement Goal { get; set; }

        [FindsBy(How = How.XPath, Using = "//metric-chooser [@metric-title = \'Numerator\'] //button")]

        public IWebElement Numerator { get; set; }

        [FindsBy(How = How.XPath, Using = "//metric-chooser [@metric-title = \'Denominator\'] //button")]

        public IWebElement Denominator { get; set; }

        [FindsBy(How = How.XPath, Using = "//span [@ng-click = 'addMetric()'] //button")]

        public IWebElement AddMetric { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [@type = 'button'] [@ng-click = 'editComplete()']")]

        public IWebElement BackToList { get; set; }

        [FindsBy(How = How.XPath, Using = "//filter [contains (@filter-data, 'Data')]  //select ")]

        public IWebElement SelectFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//filter [contains (@filter-data, 'metric')]  //select ")]

        public IWebElement SingleFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//filter [contains (@filter-data, 'numerator')]  //select ")]

        public IWebElement NumeratorFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//filter [contains (@filter-data, 'denominator')]  //select ")]

        public IWebElement DenominatorFilter { get; set; }



        [FindsBy(How = How.XPath, Using = "//input [contains (@placeholder, 'title')]")]

        public IWebElement WidgetName { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea")]

        public IWebElement Description { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [@ng-model = 'metricType.Label']")]

        public IWebElement MetricLabel { get; set; }


        //axis

        [FindsBy(How = How.XPath, Using = "//input [contains (@ng-model, 'numberOfC')]")]

        public IWebElement Characterlimit { get; set; }

        [FindsBy(How = How.XPath, Using = "//input [contains (@ng-model, 'limit')]")]

        public IWebElement ItemLimit { get; set; }

        public IWebElement Sorting(int index)
        {
            return Properties.Driver.FindElement(By.XPath($"//input [contains (@ng-model, 'sorting')] [@value ='{index}']"));
        }

        [FindsBy(How = How.XPath, Using = "//input [contains (@ng-model, 'TotalShow')]")]

        public IWebElement TotalLine { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [contains (@ng-model, 'sortingMetric')]")]

        public IWebElement SortingMetric { get; set; }



        //Formatting

        [FindsBy(How = How.XPath, Using = "//select [@ng-model = 'numberFormat.numberType']")]

        public IWebElement NumberFormat { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [@ng-model = 'numberFormat.decimalPalces']")]

        public IWebElement Decimal{ get; set; }

        [FindsBy(How = How.XPath, Using = "//input [contains (@ng-model, 'Commas')]")]

        public IWebElement ShowCommas { get; set; }

        public IWebElement ItemsCheck(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//filter [contains (@filter-data, '{metricName}')] //div [contains (text(), 'checked')] "));
        }

        public IWebElement CapacityWidget(int index)
        {
            return Properties.Driver.FindElement(By.XPath($"//tr [{index}] //button"));
        }

        public IWebElement ChooseChart(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//a [contains (text(), '{metricName}')]"));
        }

        public IWebElement Metric(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//li [@class = 'ng-scope'] /a[contains (text(), '{metricName}')]"));
        }

        public IWebElement MetricNumereator(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//metric-chooser [@metric-title = \'Numerator\'] //a[text() = \'{metricName}\']"));
        }

        public IWebElement MetricDenominator(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//metric-chooser [@metric-title = \'Denominator\'] //a[text() = \'{metricName}\']"));
        }

        public IWebElement Options(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//a[contains (text(), '{metricName}')]"));
        }

        public IWebElement CheckItem(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//div [contains (text(), '{metricName}')] /following-sibling:: div"));
        }

        public IWebElement CheckItemDenominator(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//filter [contains (@filter-data, 'denominator')] //div [contains (text(), '{metricName}')] /following-sibling:: div"));
        }

        public IWebElement MetricRadio(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//div [@class = \'radio\'] //input [@value = \'{metricName}\']"));
        }

        public IWebElement CustomMetricEdit(int index)
        {
            return Properties.Driver.FindElement(By.XPath($"//tr [{index}] [@ng-repeat = 'metric in metricList'] //button [1]"));
        }

        public IWebElement EnterCalc(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//button [@text = 'num'] [text() = '{metricName}']"));
        }

       public IWebElement AddFilter(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//filter [contains (@filter-data, '{metricName}')] //button [@ng-click ='add()']"));
        }



        //Print

        [FindsBy(How = How.XPath, Using = "//a [contains (@ng-click, 'Print')]")]

        public IWebElement PrintDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [contains (@onclick, 'print')] ")]

        public IWebElement Print { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button [contains (@ng-click, 'hidePrint')]")]

        public IWebElement CancelPrint { get; set; }

        [FindsBy(How = How.XPath, Using = "//label [contains (., 'All')] /input")]

        public IWebElement CheckAllWidget { get; set; }

        public IWebElement CheckWidget(int index )
        {
            return Properties.Driver.FindElement(By.XPath($"//div /div [{index}] [contains (@class, 'checkbox')]  /label [contains (., '')] /input "));
        }


        //Admin settings

        [FindsBy(How = How.XPath, Using = "//a [contains (@id, 'admin-settings')]")]

        public IWebElement AdminSettings { get; set; }

        [FindsBy(How = How.XPath, Using = " //a [contains (@ng-click, 'copy')]")]

        public IWebElement CopyDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//a [contains (@ng-click, 'remove')]")]

        public IWebElement RemoveElement { get; set; }

        public IWebElement MakeDefault(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//td [contains (., '{metricName}')] /following-sibling:: td /input [contains (@uib-tooltip, 'Make')]"));
        }

        public IWebElement CopyfromAdmin(string metricName, string copyeditremove)
        {
            return Properties.Driver.FindElement(By.XPath($"//td [contains (., '{metricName}')] /preceding-sibling:: td /span [contains (@ng-click, '{copyeditremove}')] /a"));
        }



        //Date Selection

        [FindsBy(How = How.XPath, Using = "//span [contains (@ng-click, 'popup')]")]

        public IWebElement SelectCalender { get; set; }

        [FindsBy(How = How.XPath, Using = "//button [contains (@id, 'date')]")]

        public IWebElement CalenderView { get; set; }

        public IWebElement SelectDdMmYy(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//span [text() = '{metricName}'] [@class = 'ng-binding'] /ancestor:: button"));
        }



        public IWebElement ConfigureWidget(string metricName)
        {
            return Properties.Driver.FindElement(By.XPath($"//h3 [contains (. , '{metricName}')] //a [contains (@title, 'Edit')] /i"));
        }


        //Asssertion

        [FindsBy(How = How.XPath, Using = "//* [contains (@class, 'c3-event-rect')]")]

        public IWebElement GraphPresent { get; set; }
    }
}
