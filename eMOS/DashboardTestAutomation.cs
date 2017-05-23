using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eMOS
{
    class DashboardTestAutomation : PageObjectDashboard
    {

        public void Filter(string widget = "")

        {
            Options("Filter").Clicks();

            ScpType.SelectDropdown("Number Of Period");

            if (widget == "Sparkline" || widget == "Trend Chart")

            {
                ScpType.SelectDropdown("Year To Date");
            }

            if (widget == "")

            {
                Numberof.ClearText(); Numberof.EnterText("400");

                AddFilter("Data").Clicks();

                //SingleFilter.Clicks();

                SelectFilter.WaitUntil();

                SelectFilter.SelectDropdown("Parent Task Type");

                ItemsCheck("Data").Clicks();

                CheckItem("120").Clicks();
            }
            
            else if (widget == "Compliance Heatmap")

            {
                Numberof.ClearText(); Numberof.EnterText("400");

                AddFilter("Data").Clicks();

                SelectFilter.WaitUntil();

                SelectFilter.SelectDropdown("User Compliances");

                ItemsCheck("Data").Clicks();

                CheckItem("On-Time").Clicks();

                CheckItem("Unidentified").Clicks();
            }

            else if (widget == "Compliance Table")

            {
                ScpType.SelectDropdown("Month To Date");

                Threshold.ClearText(); Threshold.EnterText("1");
            }

            else if (widget == "Heatmap")
            {
                ScpType.SelectDropdown("Month To Date");
            }

            else if (widget == "Trend Chart" || widget =="Heatmap")

            {
                AddFilter("Data").Clicks();

                SelectFilter.WaitUntil();

                SelectFilter.SelectDropdown("Parent Task Type");

                ItemsCheck("Data").Clicks();

                CheckItem("120").Clicks();
            }

            else if (widget == "Heatmap")
            {
                ScpType.SelectDropdown("Month To Date");
            }


            //CheckAll.Clicks();

        }

        public void Axis(string widget = "")

        {
            Options("Axis").Clicks();

            SelectAxis.SelectDropdown("Resources");

            AxisType.SelectDropdown("Departments");

            Characterlimit.ClearText(); Characterlimit.EnterText("10");

            if (widget == "Pareto")

            {
                ItemLimit.ClearText(); ItemLimit.EnterText("10");
            }

           else if (widget == "" || widget == "Stacked")
            {
                //ItemLimit.ClearText(); ItemLimit.EnterText("10");

                Sorting(1).Clicks();
            }

           
           else if (widget == "Comparison")

            {
                Sorting(1).Clicks();

                TotalLine.Clicks();

                SortingMetric.SelectIndex(2);
            }
        }


        public void SingleMetric()

        {
            Options("Metric").Clicks();

            MetricLabel.ClearText();

            MetricLabel.EnterText("MetricLabel");

            SelectMetric.Clicks();

            Metric("Total Completed Hours").Click();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks(); Thread.Sleep(4000);

            //CheckItem("70").WaitUntil();

            CheckItem("(70)").Clicks(); CheckItem("(85)").Clicks(); CheckItem("(80)").Clicks(); CheckItem("(75)").Clicks();

            MetricLabel.Clicks();

            //SingleFilter.Clicks();

        }

        public void RatioMetric()

        {
            Options("Metric").Clicks();

            MetricRadio("Ratio").Clicks();

            MetricLabel.ClearText();

            MetricLabel.EnterText("MetricLabel");

            //SelectMetric.Clicks();

            Numerator.Clicks();

            MetricNumereator("Total Completed Hours").Click();

            Denominator.Clicks();

            MetricDenominator("Total Completed Volume").Clicks();

            AddFilter("numerator").Clicks();

            NumeratorFilter.WaitUntil();

            NumeratorFilter.SelectDropdown("Program");

            ItemsCheck("numerator").Clicks();

            CheckItem("25").Clicks();

            //Options("Metric List Selection").Clicks();
            
            AddFilter("denominator").Clicks();

            DenominatorFilter.WaitUntil();

            DenominatorFilter.SelectDropdown("Program");

            ItemsCheck("denominator").Clicks();

            CheckItemDenominator("25").Clicks();
            
        }

        public void CustomMetricFilter()

        {
            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("(70)").Clicks(); CheckItem("(85)").Clicks(); CheckItem("(80)").Clicks(); CheckItem("(75)").Clicks();

            //SingleFilter.Clicks();

            MetricLabel.Clicks();

            BackToList.Clicks();

        }

        public void CustomMetric()

        {
            Options("Metric").Clicks();

            MetricRadio("Custom").Clicks();

            for (int i = 0; i <= 5; i++)

            {
                AddMetric.Clicks();
            }

            CustomMetricEdit(1).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Hours").Click();

            CustomMetricFilter();

            CustomMetricEdit(2).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Volume").Clicks();

            CustomMetricFilter();

            MetricLabel.ClearText();

            MetricLabel.EnterText("MetricLabel");

            CustomMetricEdit(3).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Tasks").Click();

            CustomMetricFilter();

            CustomMetricEdit(4).Clicks();

            SelectMetric.Clicks();

            Metric("Total Planned Volume").Clicks();

            CustomMetricFilter();

            CustomMetricEdit(5).Clicks();

            SelectMetric.Clicks();

            Metric("Total Planned Tasks").Click();

            CustomMetricFilter();

            CustomMetricEdit(6).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Planned Tasks").Clicks();

            CustomMetricFilter();

            var input = $"(A+(B-(C-D)*((E/F)*2)/9))".ToCharArray();

            foreach (var c in input)
            {
                EnterCalc("" + c).Clicks();
            }
            
        }


        public void Formatting(string widget = "")

        {
            
            if (widget == "Sparkline")

            {
                NumberFormat.SelectDropdown("Time");
            }
            
            NumberFormat.SelectDropdown("Number");

            Decimal.SelectDropdown("3");

            ShowCommas.Clicks();

            if (widget == "" || widget == "Heatmap")

            {
                AddCondition.Clicks();

                AddConditionTo.EnterText("10000");

                AddConditionFrom.EnterText("90000");

                ColorSelect.Clicks();

                SelectColor.Clicks();

            }
            
        }


        public void BasenGoal(double i, double j)

        {
            Base.ClearText(); Goal.ClearText();

            Base.EnterText(i.ToString());

            Goal.EnterText(j.ToString());
        }


        public void DashboardInitialize(string widgetName, string widget = "")

        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd THH:mm:ss");

            DashboardTab.Clicks(); Thread.Sleep(7000);

            DashboardDropdown.Clicks(); Thread.Sleep(2000);

            SelectDashboard("Add new").Clicks(); Thread.Sleep(2000);

            DashboardName.WaitUntil();

            DashboardName.ClearText(); DashboardName.EnterText(" Automate  " + timeStamp); Thread.Sleep(2000);

            AddNewWidget.Clicks(); Thread.Sleep(2000);

            ChooseChart(widgetName).Clicks(); Thread.Sleep(2000);

            SaveDashboard.Clicks(); Thread.Sleep(2000);

            DashboardGear.WaitUntil();

            DashboardGear.Clicks();

            EditDashboard.WaitUntil();

            EditDashboard.Clicks();

            ConfigureDashboard.Clicks(); Thread.Sleep(2000);

            if (widget == "")

            {
                Options("Basic").Clicks();

                Description.EnterText("...Description...");

            }
            
        }


        public void Apply()

        {
            ApplySettings.Clicks(); Thread.Sleep(2000);

            SaveDashboard.Clicks();
        }


        public void Delete()

        {
            DashboardGear.Clicks();

            DeleteDashboard.Clicks(); Thread.Sleep(2000);

            Properties.Driver.SwitchTo().Alert().Accept();
        }


        public void SingleOrPareto(string widgetName)

        {

            DashboardInitialize(widgetName);

            SingleMetric();

            RatioMetric();

            CustomMetric();

            Filter();

            Axis(widgetName);

            Options("Formatting").Clicks();

            Formatting();

            Options("Base").Clicks();

            BasenGoal(1000, 9000);

            WidgetName.ClearText(); WidgetName.EnterText("One");

            Apply();

        }


        
        public void CapacityWidget()

        {
            DashboardInitialize("Capacity", "Capacity");

            CapacityWidget(1).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Hours").Click();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            //CheckAll.Clicks();

            BackToList.Clicks();

            CapacityWidget(2).Clicks();

            MetricRadio("Ratio").Clicks();

            //SelectMetric.Clicks();

            Numerator.Clicks();

            MetricNumereator("Total Completed Hours").Click();

            AddFilter("numerator").Clicks();

            NumeratorFilter.WaitUntil();

            NumeratorFilter.SelectDropdown("Department");

            ItemsCheck("numerator").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            Denominator.Clicks();

            MetricDenominator("Total Completed Volume").Clicks();

            AddFilter("denominator").Clicks();

            DenominatorFilter.WaitUntil();

            DenominatorFilter.SelectDropdown("Department");

            ItemsCheck("denominator").Clicks();

            CheckItemDenominator("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            BackToList.Clicks();

            CapacityWidget(3).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Hours").Click();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            //CheckAll.Clicks();

            BackToList.Clicks();

            CapacityWidget(4).Clicks();

            MetricRadio("Custom").Clicks();

            for (int i = 0; i <= 5; i++)

            {
                AddMetric.Clicks();
            }

            CustomMetricEdit(1).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Hours").Click();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            BackToList.Clicks();

            CustomMetricEdit(2).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Volume").Clicks();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            BackToList.Clicks();

            CustomMetricEdit(3).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Tasks").Click();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            BackToList.Clicks();

            CustomMetricEdit(4).Clicks();

            SelectMetric.Clicks();

            Metric("Total Planned Volume").Clicks();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            BackToList.Clicks();

            CustomMetricEdit(5).Clicks();

            SelectMetric.Clicks();

            Metric("Total Planned Tasks").Click();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            BackToList.Clicks();

            CustomMetricEdit(6).Clicks();

            SelectMetric.Clicks();

            Metric("Total Completed Planned Tasks").Clicks();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            BackToList.Clicks();

            var input = $"(A+(B-(C-D)*((E/F)*2)/9))".ToCharArray();

            foreach (var c in input)
            {
                EnterCalc("" + c).Clicks();
            }
            
            Apply();

        }

        public void SparkLine()

        {
            DashboardInitialize("Sparkline");

            Options("Metric").Clicks();

            for (int i = 0; i <= 3; i++)

            {
                AddMetric.Clicks();
            }

            CustomMetricEdit(1).Clicks();

            CustomMetric(); Formatting();

            BackToList.Clicks();

            CustomMetricEdit(2).Clicks();

            CustomMetric(); Formatting();

            BackToList.Clicks();

            CustomMetricEdit(3).Clicks();

            CustomMetric(); Formatting();

            BackToList.Clicks();

            CustomMetricEdit(4).Clicks();

            CustomMetric(); Formatting();

            BackToList.Clicks();

            Filter("Sparkline");

            Axis("Sparkline");

            Apply();
        }

        public void StackedComparison(string widgetName)

        {
            DashboardInitialize(widgetName);

            Options("Metric").Click();

            for (int i = 0; i <= 3; i++)

            {
                AddMetric.Clicks();
            }

            if (widgetName == "Stacked")

            {
                CustomMetricEdit(1).Clicks();

                SingleMetric();

                BackToList.Clicks();

                CustomMetricEdit(2).Clicks();

                SingleMetric();

                BackToList.Clicks();

                CustomMetricEdit(3).Clicks();

                SingleMetric();

                BackToList.Clicks();

                CustomMetricEdit(4).Clicks();

                SingleMetric();

                BackToList.Clicks();
            }

            else if (widgetName == "Comparison")

            {
                CustomMetricEdit(1).Clicks();

                RatioMetric();

                MetricLabel.Clicks(); BackToList.Clicks();

                CustomMetricEdit(2).Clicks();

                RatioMetric();

                MetricLabel.Clicks(); BackToList.Clicks();

                CustomMetricEdit(3).Clicks();

                RatioMetric();

                MetricLabel.Clicks(); BackToList.Clicks();

                CustomMetricEdit(4).Clicks();

                RatioMetric();

                MetricLabel.Clicks(); BackToList.Clicks();
                
            }
            
            Filter();

            Axis(widgetName);

            Options("Base").Clicks();

            BasenGoal(.5, .98);

            Options("Formatting").Clicks();

            Formatting(widgetName);

            Apply();
        }


        public void HeatMap()

        {
            DashboardInitialize("HeatMap");

            Options("Metric").Clicks();

            RatioMetric();

            Options("Axis").Clicks();

            AxisType.SelectDropdown("Day");

            SeriesSelection.SelectDropdown("Resources");

            SeriesType.SelectDropdown("Departments");

            Characterlimit.ClearText(); Characterlimit.EnterText("10");

            Options("Formatting").Clicks();

            Formatting();

            Filter("Heatmap");

            Apply();
            
        }

        public void TrendChart()

        {
            DashboardInitialize("Trend");

            Options("Metric").Clicks();

            CustomMetric();

            Options("Axis").Clicks();

            AxisType.SelectDropdown("Day");

            SeriesSelection.SelectDropdown("Resources");

            SeriesType.SelectDropdown("Departments");

            Characterlimit.ClearText(); Characterlimit.EnterText("10");

            Options("Base").Clicks();

            BasenGoal(.5, 1.5);

            Filter("Trend Chart");

            Apply();
        }

        public void ComplianceTable()

        {
            DashboardInitialize("Compliance Table");

            Filter("Compliance Table");

            Options("Axis").Clicks();

            AxisType.SelectDropdown("Day");

            Options("Formatting").Clicks();

            //Formatting();

            Apply();
        }

        public void ComplianceHeatMap()

        {
            DashboardInitialize("Compliance Heatmap");

            Filter("Compliance Heatmap");

            Options("Axis").Clicks();

            AxisType.SelectDropdown("Day");

            SeriesSelection.SelectDropdown("Resources");

            SeriesType.SelectDropdown("Departments");

            Options("Formatting").Clicks();

            Formatting();

            Apply();
        }


        public void DashboardPrint()

        {
            DashboardTab.Clicks(); Thread.Sleep(5000);

            DashboardDropdown.Clicks();

            SelectDashboard("Testing").Clicks(); Thread.Sleep(2000);

            DashboardGear.Clicks(); PrintDashboard.Clicks(); Thread.Sleep(5000);

            CheckAllWidget.Clicks(); Thread.Sleep(3000);

            CheckAllWidget.Clicks();

            CancelPrint.Clicks(); Thread.Sleep(2000);

            DashboardGear.Clicks(); PrintDashboard.Clicks(); Thread.Sleep(5000);

            CheckAllWidget.Clicks(); Thread.Sleep(3000);

            CheckWidget(3).Clicks(); CheckWidget(5).Clicks(); CheckWidget(7).Clicks();

            Print.Clicks();
        }


        public void DashboardAdmin()

        {
            SingleOrPareto("Single");

            DashboardGear.Clicks();

            AdminSettings.Clicks(); Thread.Sleep(2000);

            MakeDefault("Automate").Clicks();

            DashboardTab.Clicks();

            DashboardGear.Clicks(); EditDashboard.Clicks();

            ConfigureDashboard.Clicks();

            Options("Base").Clicks();

            BasenGoal(200, 1000);

            Apply();

            DashboardGear.Clicks(); CopyDashboard.Clicks();

            Delete();

            DashboardGear.Clicks(); AdminSettings.Clicks(); Thread.Sleep(2000);

            CopyfromAdmin("Automate", "copy").Clicks(); Thread.Sleep(2000);

            CopyfromAdmin("Copy of", "edit").Clicks();

            RemoveElement.Clicks();

            SaveDashboard.Clicks();
        }


        public void ChangeDate(string date, string month, string year)

        {
            //DashboardTab.Clicks(); Thread.Sleep(5000);

            //DashboardDropdown.Clicks();

            //SelectDashboard("Testing").Clicks(); Thread.Sleep(2000);

            SelectCalender.Clicks();

            CalenderView.Clicks(); CalenderView.Clicks();

            SelectDdMmYy(year).Clicks();

            SelectDdMmYy(month).Clicks();

            SelectDdMmYy(date).Clicks();
        }

    }
}
