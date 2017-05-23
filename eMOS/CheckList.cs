using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;

namespace eMOS
{
    public class CheckList
    {
        static void Main(string[] args)
        {

        }

        [TestFixture]

        public class PlanLogTest

        {
           [OneTimeSetUp]

            public void Initialize()
            {
                var options = new ChromeOptions();

                options.AddArgument("--start-maximized");

                options.AddUserProfilePreference("credentials_enable_service", false);

                options.AddUserProfilePreference("profile.password_manager_enabled", false);

                DbOperation operation = new DbOperation();

                //operation.StoreSnap();

                operation.ReStoreSnap();

                Properties.Driver = new ChromeDriver(options) { Url = ConfigurationManager.AppSettings["app-url"] };

            }


            [Test, Order(0)]


            public void Plan_Log()
            {
                WebDriverWait wait = new WebDriverWait(Properties.Driver, TimeSpan.FromSeconds(10));

                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                //automate.Login("admin", "eMos123!");

                automate.Login("automationuser1", "eMos123!");

                automate.PlanLog();
                
            }


            [Test, Order(1)]

            public void Favorties_R_Present()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.FavPresent();

            }


            [Test, Order(2)]

            public void Fav_RE_Correct()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.FavReCorrect();

//                DbOperation operation = new DbOperation();
//
//                operation.StoreSnap();

            }


            [Test, Order(3)]

            public void Add_New_Task_Unsaved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddNewTask1();
            }


            [Test, Order(4)]

            public void Add_Existing_Task_Unsaved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddExTask1();
            }


            [Test, Order(5)]

            public void Add_Favortie_Task_Unsaved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddFavoriteTasks1();
            }


            [Test, Order(6)]

            public void Add_Multiple_Resouirces_Unsaved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddMultipleResource();
            }


            [Test, Order(7)]

            public void Add_Same_Resource_Unasaved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddSameResource();
            }


            [Test, Order(8)]

            public void Enter_Volume_Unsaved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.EnterVolume();
                
            }


            [Test, Order(9)]

            public void Save_Plan_1()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.PlanSave();

//                DbOperation operation = new DbOperation();
//
//                operation.StoreSnap();
            }


            [Test, Order(10)]

            public void Check_TimeVolume_Calculation_1()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.CheckTimeCalc();
            }


            [Test, Order(11)]

            public void Delete_Resource()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.DeleteResource();
            }


            [Test, Order(12)]

            public void Delete_Task_1()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.DeleteTask1();
            }


            [Test, Order(13)]

            public void Save_Plan_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.PlanSave2();
            }


            [Test, Order(14)]

            public void Check_TimeVolume_Calculation_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.CheckTimeCalc2();
            }


            [Test, Order(15)]

            public void Add_New_Task_Saved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddNewTask2();
            }


            [Test, Order(16)]

            public void Add_Existing_Task_Saved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddExTask2();
            }


            [Test, Order(17)]

            public void Add_Favorite_Task_Saved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddFavoriteTask2();
            }


            [Test, Order(18)]

            public void Add_Resource_Saved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.ResouceAdd2();
            }


            [Test, Order(19)]

            public void Enter_Volume_Saved_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.EnterVolume2("400");
            }


            [Test, Order(20)]

            public void Approve_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.PlanApprove("automationuser2");
            }


            [Test, Order(21)]

            public void Check_TimeVolume_Calculation_3()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.CheckTimeCalc3();
            }



            [Test, Order(22)]

            public void Add_New_Task_LogMode()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddNewTask3();
            }


            [Test, Order(23)]

            public void Add_Exisiting_Task_LogMode()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddExTask3();
            }


            [Test, Order(24)]

            public void Add_Favorite_Task_LogMode()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddFavoriteTask3();
            }


            [Test, Order(25)]

            public void Add_Resource_LogMode()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.ResourceAdd3();
            }


            [Test, Order(26)]

            public void Add_Barrier()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.BarrierAdd();
            }


            [Test, Order(27)]

            public void Enter_Volume_LogMode()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.EnterVolume3();
            }


            [Test, Order(28)]

            public void Add_Barrier_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.BarrierAdd2();
            }


            [Test, Order(29)]

            public void Save_Log()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.LogSave();
            }


            [Test, Order(30)]

            public void Check_TimeVolume_Calculation_4()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.CheckTimeCalc4();
            }



            [Test, Order(31)]

            public void Remove_Barrier()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.BarrierRemove();
            }


            [Test, Order(32)]

            public void Add_New_Task_LogMode_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddNewTask4();
            }


            [Test, Order(33)]

            public void Add_Existing_Task_LogMode_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddExTask4();
            }


            [Test, Order(34)]

            public void Add_Favorite_Task_LogMode_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.AddFavoriteTask4();
            }


            [Test, Order(35)]

            public void Add_Resource_LogMod_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.ResourceAdd4();
            }


            [Test, Order(36)]

            public void Add_Barrier_3()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.BarrierAdd3();
            }


            [Test, Order(37)]

            public void Enter_Volume_LogMode_2()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.EnterVolume4();
            }


            [Test, Order(38)]

            public void Approve_Log()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.LogApprove();
            }


            [Test, Order(39)]

            public void Check_TimeVolume_Calculation_5()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.CheckTimeCalc5();
            }


            //            [Test, Order(40)]
            //
            //            public void Add_Actuals()
            //
            //            {
            //                AutomatedPlanLog automate = new AutomatedPlanLog();
            //
            //                automate.AddActual();
            //            }


            [Test, Order(41)]

            public void View_Check()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.ViewChecking();
            }


            [Test, Order(42)]

            public void Copy_Existing_Plan()

            {
                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.CopyPlan();

                DbOperation operation = new DbOperation();

                operation.ReStoreSnap();
            }

            [TearDown, Order(43)]

            public void EndTest()

            {
//                DbOperation operation = new DbOperation();
//
//                operation.ReStoreSnap();

                //Properties.driver.Close();
            }
        }

        public class DashboardTest

        {
            [OneTimeSetUp]

            public void Initialize()
            {
                var options = new ChromeOptions();

                options.AddArgument("--start-maximized");

                options.AddUserProfilePreference("credentials_enable_service", false);

                options.AddUserProfilePreference("profile.password_manager_enabled", false);

                Properties.Driver = new ChromeDriver(options) { Url = ConfigurationManager.AppSettings["app-url"] };

                //Properties.driver = new ChromeDriver(options) {Url = "http://dashboard.emos.io"};

                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.Login("admin", "eMos123!");


            }


            [Test, Order(0)]


            public void Dashboard()
            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                PlanLogTestAutomation automate = new PlanLogTestAutomation();

                automate.Login("admin", "eMos123!");

                //operation.StoreSnap();

                //operation.ReStoreSnap();

                //automate.Login("superuser", "Ru55el.");

                //automate.Login("teammember1", "Ru55el.");
                
                //auto.ChangeDate("31", "August", "2016");

            }


            [Test, Order(1)]

            public void SingleMetric()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.SingleOrPareto("Single");
            }


            [Test, Order(2)]

            public void ParetoChart()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.SingleOrPareto("Pareto");
            }


            [Test, Order(3)]

            public void CapacityWidget()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.CapacityWidget();
            }

            [Test, Order(4)]

            public void SparkLine()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.SparkLine();
            }


            [Test, Order(5)]

            public void ComparisonChart()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.StackedComparison("Comparison");
            }

            [Test, Order(6)]

            public void StackedBarChart()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.StackedComparison("Stacked");
            }


            [Test, Order(7)]

            public void HeatMap()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.HeatMap();
            }


            [Test, Order(8)]

            public void TrendChart()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.TrendChart();
            }

            [Test, Order(9)]

            public void ComplianceTable()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.ComplianceTable();
            }


            [Test, Order(10)]

            public void ComplianceHeatMap()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.ComplianceHeatMap();
            }


            [Test, Order(11)]

            public void DashboardPrint()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.DashboardPrint();
            }


            [Test, Order(12)]

            public void DashboardAdmin()

            {
                DashboardTestAutomation auto = new DashboardTestAutomation();

                auto.DashboardAdmin();
            }

        }
    }
}
