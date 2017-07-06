using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using NUnit.Framework;

namespace eMOS
{
    class DashboardTestAutomation : PageObjectDashboard
    {

        PlanLogTestAutomation PlanLog = new PlanLogTestAutomation();

       
        public void WaitforIt(int pause)

        {
            Thread.Sleep(pause);
        }

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


        public void Link()

        {
            Options("Link").Clicks();

            SelectLink("Drill Down").Clicks(); WaitforIt(Properties.LittlePause);
        }


        public void SingleMetric(string metricName)

        {
            Options("Metric").Clicks();

            MetricLabel.ClearText();

            MetricLabel.EnterText("MetricLabel");

            SelectMetric.Clicks();

            Metric(metricName).Clicks();

            if (metricName.Contains("Average"))

            {
                AverageAxis.SelectDropdown("Hour");
            }
            
            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks(); WaitforIt(Properties.LittlePause);

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


        public void DashboardInitialize(string dashboardName)

        {
            string timeStamp = DateTime.Now.ToString("d-MM-yyyy, HH:mm:ss");

            DashboardTab.Clicks(); WaitforIt(Properties.LittlePause);

            DashboardDropdown.Clicks(); WaitforIt(Properties.LittlePause);

            SelectDashboard("Add new").Clicks(); WaitforIt(Properties.LittlePause);

            DashboardName.WaitUntil();

            DashboardName.ClearText(); DashboardName.EnterText(" " + dashboardName + " " + timeStamp); WaitforIt(Properties.LittlePause);

            SaveDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            /*AddNewWidget.Clicks(); WaitforIt(Properties.LittlePause);

            ChooseChart(widgetName).Clicks(); WaitforIt(Properties.LittlePause);

            SaveDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            DashboardGear.WaitUntil();

            DashboardGear.Clicks();

            EditDashboard.WaitUntil();

            EditDashboard.Clicks();
                
            ConfigureDashboard(widgetName).Clicks(); WaitforIt(Properties.LittlePause);

            if (widget == "")

            {
                Options("Basic").Clicks();

                Description.EnterText("...Description...");

            }*/

        }


        public void AddWidget(string widgetName, string widget = "")

        {
            DashboardGear.WaitUntil(); DashboardGear.Clicks();

            EditDashboard.WaitUntil();  EditDashboard.Clicks();

            AddNewWidget.Clicks(); WaitforIt(Properties.LittlePause);

            ChooseChart(widgetName).Clicks(); WaitforIt(Properties.LittlePause);

            SaveDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            DashboardGear.WaitUntil(); DashboardGear.Clicks();

            EditDashboard.WaitUntil(); EditDashboard.Clicks();

            ConfigureDashboard(widgetName).Clicks(); WaitforIt(Properties.LittlePause);

            if (widget != "" && widgetName != "Capacity")

            {
                Options("Basic").Clicks();

                Description.EnterText("...Description...");

            }
        }


        public void Apply()

        {
            ApplySettings.Clicks(); WaitforIt(Properties.LittlePause);

            SaveDashboard.Clicks();
        }


        public void Delete()

        {
            DashboardGear.Clicks();

            DeleteDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            Properties.Driver.SwitchTo().Alert().Accept();
        }


        public void SingleOrPareto(string widgetName, string widget)

        {

            //DashboardInitialize(widgetName);

            AddWidget(widgetName);

            SingleMetric("Total Completed Hours");

            RatioMetric();

            CustomMetric();

            Filter();

            Axis(widgetName);

            Options("Formatting").Clicks();

            Formatting();

            Options("Base").Clicks();

            BasenGoal(1000, 4000);

            WidgetName.ClearText(); WidgetName.EnterText(widget);

            Apply();

        }


        
        public void CapacityWidget()

        {
            AddWidget("Capacity");

            CapacityWidget(1).Clicks();

            MetricLabel.ClearText(); MetricLabel.EnterText("Capacity Metric 1");

            SelectMetric.Clicks();

            Metric("Total Planned Hours").Click();

            AddFilter("metric").Clicks();

            SingleFilter.WaitUntil();

            SingleFilter.SelectDropdown("Department");

            ItemsCheck("metric").Clicks();

            CheckItem("Alton - Alt (70)").Clicks();

            Options("Metric List Selection").Clicks();

            //CheckAll.Clicks();

            BackToList.Clicks();

            CapacityWidget(2).Clicks();

            MetricLabel.ClearText(); MetricLabel.EnterText("Capacity Metric 2");

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

            MetricLabel.ClearText(); MetricLabel.EnterText("Capacity Metric 3");

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

            MetricLabel.ClearText(); MetricLabel.EnterText("Capacity Metric 4");

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
            //DashboardInitialize();

            AddWidget("Sparkline");

            Options("Metric").Clicks();

            for (int i = 0; i <= 3; i++)

            {
                AddMetric.Clicks();
            }

            CustomMetricEdit(1).Clicks();

            CustomMetric(); Formatting();

            BackToList.Clicks();

            CustomMetricEdit(2).Clicks();

            RatioMetric(); Formatting();

            BackToList.Clicks();

            CustomMetricEdit(3).Clicks();

            CustomMetric(); Formatting();

            BackToList.Clicks();

            CustomMetricEdit(4).Clicks();

            SingleMetric("Total Barrier Hours"); Formatting();

            BackToList.Clicks();

            Filter("Sparkline");

            Axis("Sparkline");

            Apply();
        }

        public void StackedComparison(string widgetName)

        {
            //DashboardInitialize(widgetName);

            ResetFilter.Clicks();

            AddWidget(widgetName);

            Options("Metric").Click();

            for (int i = 0; i <= 3; i++)

            {
                AddMetric.Clicks();
            }

            if (widgetName == "Stacked")

            {
                CustomMetricEdit(1).Clicks();

                SingleMetric("Total Completed Planned Volume");

                BackToList.Clicks();

                CustomMetricEdit(2).Clicks();

                SingleMetric("OEE");

                BackToList.Clicks();

                CustomMetricEdit(3).Clicks();

                SingleMetric("Accountable Hours");

                BackToList.Clicks();

                CustomMetricEdit(4).Clicks();

                SingleMetric("Average Planned Volume");

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

            Link();

            Apply(); WaitforIt(Properties.InactivePhase); LinkClick.Clicks();
            
        }


        public void HeatMap()

        {
            //DashboardInitialize();

            AddWidget("HeatMap");

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
            //DashboardInitialize();

            AddWidget("Trend Chart");

            Options("Metric").Clicks();

            CustomMetric();

            Options("Axis").Clicks();

            AxisType.SelectDropdown("Month");

            SeriesSelection.SelectDropdown("Resources");

            SeriesType.SelectDropdown("Departments");

            Characterlimit.ClearText(); Characterlimit.EnterText("10");

            Options("Base").Clicks();

            BasenGoal(.5, 1.5);

            Filter("Trend Chart");

            Apply(); WaitforIt(Properties.InactivePhase);
        }

        public void ComplianceTable()

        {
            //DashboardInitialize();

            AddWidget("Compliance Table");

            Filter("Compliance Table");

            Options("Axis").Clicks();

            AxisType.SelectDropdown("Day");

            Options("Formatting").Clicks();

            //Formatting();

            Apply();
        }

        public void ComplianceHeatMap()

        {
            //DashboardInitialize();

            AddWidget("Compliance Heatmap");

            Filter("Compliance Heatmap");

            Options("Axis").Clicks();

            AxisType.SelectDropdown("Day");

            SeriesSelection.SelectDropdown("Resources");

            SeriesType.SelectDropdown("Departments");

            Options("Formatting").Clicks();

            Formatting();

            Apply(); WaitforIt(Properties.LittlePause);
        }


        public void DashboardPrint()

        {
            DashboardTab.Clicks(); WaitforIt(Properties.LittlePause);
        
            DashboardDropdown.Clicks();

            SelectDashboard("Testing").Clicks(); WaitforIt(Properties.LittlePause);

            DashboardGear.Clicks(); PrintDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            CheckAllWidget.Clicks(); WaitforIt(Properties.LittlePause);

            CheckAllWidget.Clicks();

            CancelPrint.Clicks(); WaitforIt(Properties.LittlePause);

            DashboardGear.Clicks(); PrintDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            CheckAllWidget.Clicks(); WaitforIt(Properties.LittlePause);

            CheckWidget(3).Clicks(); CheckWidget(5).Clicks(); CheckWidget(7).Clicks();

            Print.Clicks(); WaitforIt(Properties.LittlePause);

            SendKeys.SendWait("{ESC}");
            
        }


        public void DashboardChild()

        {
            DashboardGear.Clicks();

            AdminSettings.Clicks(); WaitforIt(Properties.LittlePause);

            SetAsChild("Drill Down").Clicks();

            CopyfromAdmin("Drill Down", "edit").Clicks(); WaitforIt(Properties.LittlePause);

            DashboardGear.Clicks(); WaitforIt(Properties.LittlePause);

            EditDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            ConfigureDashboard("One").Clicks();

            Options("Base").Clicks();

            BasenGoal(200, 1000);

            Apply(); WaitforIt(Properties.LittlePause);
        }

        public void DashboardAdmin()

        {
            SingleOrPareto("Single", "One"); WaitforIt(Properties.LittlePause);

            DashboardGear.Clicks();

            AdminSettings.Clicks(); WaitforIt(Properties.LittlePause);

            MakeDefault("Default").Clicks();

            //SetAsChild("Automate").Clicks();

            DashboardTab.Clicks(); WaitforIt(Properties.LittlePause);

            DashboardGear.Clicks(); WaitforIt(Properties.LittlePause);

            EditDashboard.Clicks(); WaitforIt(Properties.LittlePause);

            ConfigureDashboard("One").Clicks();

            Options("Base").Clicks();

            BasenGoal(200, 1000);

            Apply(); WaitforIt(Properties.LittlePause);

            DashboardGear.Clicks(); CopyDashboard.Clicks();

            Delete();

            DashboardGear.Clicks(); AdminSettings.Clicks(); WaitforIt(Properties.LittlePause);

            CopyfromAdmin("Default", "copy").Clicks(); WaitforIt(Properties.LittlePause);

            CopyfromAdmin("Copy of", "edit").Clicks();

            Delete();
        }


        public void DashboardShare()

        {
            ComplianceHeatMap(); WaitforIt(Properties.LittlePause);

            DashboardGear.Clicks(); AdminSettings.Clicks(); WaitforIt(Properties.LittlePause);

            CopyfromAdmin("Shared", "share").Clicks(); WaitforIt(Properties.LittlePause);

            DahsboardSelect("Shared").Clicks();

            SelectUser.SelectDropdown("Automation User 2");

            AddUser.Clicks(); SaveShare.Clicks();

            LogOut.Clicks();

            PlanLog.Login("automationuser2", "eMos123!"); WaitforIt(Properties.LittlePause);

            DashboardTab.Clicks();
        }


        public void ChangeDate(string date, string month, string year)

        {
           
            WaitforIt(Properties.LittlePause);

            SelectCalender.Clicks();

            CalenderView.Clicks(); CalenderView.Clicks();

            SelectDdMmYy(year).Clicks();

            SelectDdMmYy(month).Clicks();

            SelectDdMmYy(date).Clicks();
        }


        public void GraphAssert()

        {
            WaitforIt(Properties.LittlePause);

            Assert.That(GraphPresent.Displayed);
        }

        public void HeatMapAssert()

        {
            WaitforIt(Properties.LittlePause);

            Assert.That(HeatMapPresent.Displayed);
        }

        public void ComplianceAssert()

        {
            WaitforIt(Properties.LittlePause);

            Assert.That(ComplianceTableAssert.Displayed);
        }

        public void DashboardNameAssert(string dashboardName)

        {
            WaitforIt(Properties.LittlePause);

            Assert.That(NameOfDashboard(dashboardName).Displayed);
        }
    }
}
