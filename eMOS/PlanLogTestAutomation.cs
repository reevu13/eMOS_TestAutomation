using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace eMOS
{
    class PlanLogTestAutomation : PageObjectPlanLog
    {

        public void WaitforIt(int pause)

        {
            Thread.Sleep(pause);
        }

        public void Login(string userId, string passcode)
        {
            UserName.WaitUntil(); UserName.ClearText();

            UserName.EnterText(userId);

            Password.ClearText(); Password.EnterText(passcode);

            LoginBtn.Clicks();

        }

        public void PlanLog()
        {
            PlanLogTab.WaitUntil();

            PlanLogTab.Clicks();

            DprtmntSelect.WaitUntil();

            DprtmntSelect.SelectDropdown("Granite City - GrC");

            TeamSelect.WaitUntil();

            TeamSelect.SelectDropdown("Test Team");

            UserSelect.WaitUntil();

            UserSelect.SelectDropdown("Automation User 1");

            Console.WriteLine("The selected Department is " + DprtmntSelect.GetTextFromDdL());

            Console.WriteLine("The selected Team is " + TeamSelect.GetTextFromDdL());

            Console.WriteLine("The selected User is " + UserSelect.GetTextFromDdL());

            string timeStamp = DateTime.Now.ToString("M'/'d'/'yyyy");

            Console.WriteLine("PC Date " + timeStamp);

            Console.WriteLine("Plan/Log Date " + Date.GetText());

            Assert.IsTrue(PlanStatus("Not Started").Displayed);

            Assert.IsTrue(Date.GetText().Equals(timeStamp));

            /*Calender.Clicks();

            for (var i = 0; i < 11; i++)
            {

                PrevDate.WaitUntil();

                PrevDate.Clicks();
            }

            SelectDate(26).Clicks();

            while (true)
            {
                if (PlanStatus.Text != "Not Started")
                {
                    Calender.Clicks();

                    for (var j = 0; j < 10; j++)
                    {
                        _count++;

                        PrevDate.WaitUntil();

                        PrevDate.Clicks();
                    }

                    SelectDate.Clicks();
                }

                else
                {
                    break;
                }
            }*/

        }


        public void RePlanLog()

        {
            PlanLogTab.Clicks();

            DprtmntSelect.WaitUntil();

            DprtmntSelect.SelectDropdown("Granite City - GrC");

            TeamSelect.WaitUntil();

            TeamSelect.SelectDropdown("Test Team");

            UserSelect.WaitUntil();

            UserSelect.SelectDropdown("Automation User 1");

            string timeStamp = DateTime.Now.ToString("M'/'d'/'yyyy");

            Assert.IsTrue(Date.GetText().Equals(timeStamp));
            
        }

       
        public void FavPresent()

        {
            //WaitforIt(Properties.InactivePhase);

            WaitforIt(Properties.LittlePause);

            Assert.Multiple((() =>
            {
                Assert.IsTrue(TaskLink("Total Tasks Completed").Displayed);

                Assert.IsTrue(TaskLink("Maintenance Spend").Displayed);

                Assert.IsTrue(TaskLink("Non-Working GPS").Displayed);

                Assert.IsTrue(TaskLink("Idle>10 Minutes").Displayed);

                Assert.IsTrue(TaskLink("Hours Entered in Manager Plus").Displayed);

                Assert.IsTrue(TaskLink("Buses Out of Service > 5 Days").Displayed);

                Assert.IsTrue(TaskLink("New Out of Service Buses – DVIR").Displayed);

                Assert.IsTrue(TaskLink("Maintenance Spend - WTD").Displayed);

                Assert.IsTrue(TaskLink("Breakdowns").Displayed);

                Assert.IsTrue(TaskLink("Avg Idle Time").Displayed);

            }));

        }


        public void FavReCorrect()

        {
            //WaitforIt(Properties.InactivePhase);

            WaitforIt(Properties.LittlePause);

            Assert.Multiple((() =>
            {
                Assert.IsTrue(ReUnits(0, 200).Displayed);

                Assert.IsTrue(ReUnits(1, 400).Displayed);

                Assert.IsTrue(ReUnits(2, 600).Displayed);

                Assert.IsTrue(ReUnits(3, 100).Displayed);

                Assert.IsTrue(ReUnits(4, 500).Displayed);

                Assert.IsTrue(ReUnits(5, 60).Displayed);

                Assert.IsTrue(ReUnits(6, 100).Displayed);

                Assert.IsTrue(ReUnits(7, 450).Displayed);

                Assert.IsTrue(ReUnits(8, 500).Displayed);

                Assert.IsTrue(ReUnits(9, 200).Displayed);

            }));

        }


        public void AddNewTask1()

        {
            TaskElement("Maintenance Spend - WTD").Clicks();

            RemoveTask.WaitUntil();

            RemoveTask.Clicks();

            AddBtn.Clicks();

            AddNewTask.Clicks();

            TaskName.WaitUntil();

            TaskName.EnterText("Test Task 1");

            TaskTypeParent("Office Tasks").Clicks();

            TaskTypeChild("Discipline").Clicks(); WaitforIt(Properties.VeryInactivePhase); 

            Complexity.SelectIndex(1); WaitforIt(Properties.VeryInactivePhase); 

            SaveTask.WaitUntil();

            SaveTask.Clicks();

            AddBtn.WaitUntil();

        }


        public void AddExTask1()
        {
            AddBtn.WaitUntil();

            AddBtn.Clicks();

            AddExistingTask.Clicks(); WaitforIt(Properties.VeryInactivePhase);

            SelectTask(5).WaitUntil();

            SelectTask(5).Clicks();

            TaskComment.EnterText("Existing Task 1");

            AddExTask.WaitUntil();

            AddExTask.Clicks();

            AddBtn.WaitUntil();

        }


        public void AddFavoriteTasks1()

        {
            AddBtn.WaitUntil();

            AddBtn.Clicks();

            AddFavTask.Clicks(); WaitforIt(Properties.InactivePhase);

            SelectTask(9).WaitUntil();

            SelectTask(9).Clicks();

            FavComment.EnterText("Favorite Task 1");

            FavAdded.Clicks();
        }

        public void AddMultipleResource()

        {
            TaskElement("Total Tasks Completed").WaitUntil(); TaskElement("Total Tasks Completed").Clicks();

            AddResource.Clicks();

            ResourceType.WaitUntil();

            ResourceType.SelectDropdown("eMOSUser");

            SelectResource("Wondez").WaitUntil();

            SelectResource("Wondez").Clicks();

            SelectResource("Arroyo").Clicks();

            SelectResource("Sandra").Clicks();

            ResourceAdded.Clicks();
        }


        public void AddSameResource()

        {
            TaskElement("Non-Working GPS").WaitUntil(); TaskElement("Non-Working GPS").Clicks();

            AddResource.WaitUntil();

            AddResource.Clicks();

            ResourceType.WaitUntil();

            ResourceType.SelectDropdown("eMOSUser");

            SelectResource("Arroyo").WaitUntil();

            SelectResource("Arroyo").Clicks();

            SelectResource("Sandra").Clicks();

            ResourceAdded.Clicks();

        }


        public void EnterVolume()

        {
            //re: [1/200, 1/400, 1/600, 1/100, 1/500, 1/60, 1/100, 1/450, 1/500, 1/200]

            VolumeEntry(.005, "Wondez", 0).EnterText("100");

            VolumeEntry(.005, "Arroyo", 1).EnterText("200");

            VolumeEntry(.005, "Sandra", 2).EnterText("400");

            VolumeEntry(0.0016, "Arroyo", 3).EnterText("500");

            VolumeEntry(0.0016, "Sandra", 2).EnterText("300");

            VolumeEntry(.01, "Idle", 1).EnterText("600");
        }


        public void PlanSave()
        {
            SaveButton("Save").Clicks(); WaitforIt(Properties.InactivePhase);

            SavedElement.WaitUntil();

            Assert.That(SavedElement, Is.Not.Null);

            Assert.That(PlanStatus("New").Displayed);

            LogOut.Clicks(); WaitforIt(Properties.InactivePhase);

            Login("automationuser1", "eMos123!");

            RePlanLog(); WaitforIt(Properties.InactivePhase); //WaitforIt(Properties.InactivePhase);


        }


        public void CheckTimeCalc()

        {
            Assert.Multiple((() =>
            {
                Assert.That(TotalPLanT1.Text.Equals("2.5"));

                Assert.That(TotalPlanV1.Text.Equals("2100"));
            }));
        }


        public void DeleteResource()

        {
            WaitforIt(Properties.LittlePause); Resource(.0016, "Arroyo").WaitUntil();

            Resource(.0016, "Arroyo").Clicks();

            RemoveResource.Clicks();

            Properties.Driver.SwitchTo().Alert().Accept();
        }


        public void DeleteTask1()

        {
            TaskElement("Avg Idle Time").WaitUntil(); TaskElement("Avg Idle Time").Clicks();

            RemoveTask.Clicks();
        }

        public void PlanSave2()

        {
            SaveButton("Save").Clicks();

            SavedElement.WaitUntil();

            Assert.That(SavedElement, Is.Not.Null);

            Assert.That(PlanStatus("New").Displayed);
        }


        public void CheckTimeCalc2()
        {
            WaitforIt(Properties.InactivePhase);

            Assert.Multiple((() =>

                {
                    Assert.That(TotalPLanT1.Text.Equals("2"));

                    Assert.That(TotalPlanV1.Text.Equals("1600"));
                }

            ));

        }


        public void AddNewTask2()

        {
            WaitforIt(Properties.InactivePhase); AddBtn.WaitUntil();

            AddBtn.Clicks();

            AddNewTask.Clicks();

            TaskName.WaitUntil();

            TaskName.EnterText("Test Task 2");

            TaskTypeParent("Office Tasks").Clicks();

            TaskTypeChild("Discipline").Clicks(); WaitforIt(Properties.VeryInactivePhase);//WaitforIt(Properties.VeryInactivePhase)

            Complexity.SelectIndex(1); WaitforIt(Properties.VeryInactivePhase);

            SaveTask.WaitUntil();

            SaveTask.Clicks();

            AddBtn.WaitUntil();

        }


        public void AddExTask2()

        {
            AddBtn.WaitUntil();

            AddBtn.Clicks();

            AddExistingTask.Clicks(); WaitforIt(Properties.VeryInactivePhase); //Thread.Sleep(9000);

            SelectTask(3).Clicks();

            TaskComment.EnterText("Existing Task 2");

            AddExTask.WaitUntil();

            AddExTask.Clicks();

            AddBtn.WaitUntil();

        }


        public void AddFavoriteTask2()

        {
            AddBtn.WaitUntil(); AddBtn.Clicks();

            AddFavTask.Clicks(); WaitforIt(Properties.InactivePhase);

            SelectTask(11).Clicks();

            FavComment.EnterText("Favorite Task 2");

            FavAdded.Clicks();
        }



        public void ResouceAdd2()
        {

            TaskElement("Idle>10 Minutes").WaitUntil(); TaskElement("Idle>10 Minutes").Clicks();

            AddResource.Clicks();

            ResourceType.WaitUntil();

            ResourceType.SelectDropdown("eMOSUser");

            SelectResource("Barger").WaitUntil();

            SelectResource("Barger").Clicks();

            ResourceAdded.Clicks(); WaitforIt(Properties.InactivePhase);

        }


        public void EnterVolume2(string entry)

        {
            VolumeEntry(0.01, "Barger", 0).WaitUntil(); VolumeEntry(0.01, "Barger", 0).ClearText();

            VolumeEntry(0.01, "Barger", 0).EnterText(entry);
        }

        public void PlanApprove(string userName)

        {
            WaitforIt(Properties.InactivePhase); SaveButton("Approve").WaitUntil();

            SaveButton("Approve").Clicks();

            SavedElement.WaitUntil();

            Assert.That(SavedElement, Is.Not.Null);

            Assert.That(PlanStatus("Plan Approved").Displayed);

            LogOut.Clicks(); WaitforIt(Properties.InactivePhase);

            Login(userName, "eMos123!");

            RePlanLog(); WaitforIt(Properties.InactivePhase);

        }


        public void CheckTimeCalc3()

        {
            SaveButton("Unapprove").Clicks(); WaitforIt(Properties.InactivePhase);

            SaveButton("Save").Clicks(); SavedElement.WaitUntil();

            Assert.That(SavedElement, Is.Not.Null); Assert.That(PlanStatus("New").Displayed);

            LogOut.Clicks(); WaitforIt(Properties.InactivePhase); Login("automationuser1", "eMos123!");

            RePlanLog(); WaitforIt(Properties.InactivePhase);

            EnterVolume2("600");
            
            PlanApprove("automationuser1");

            Assert.Multiple((() =>
                {
                    Assert.That(TotalPLanT1.Text.Equals("2"));

                    Assert.That(TotalPlanV1.Text.Equals("1600"));
                }
            ));

            AddBtn.WaitUntil();

            VolumeEntry(.005, "Wondez", 1).WaitUntil();

            VolumeEntry(.005, "Wondez", 1).EnterText("200");

            VolumeEntry(.005, "Arroyo", 2).WaitUntil();

            VolumeEntry(.005, "Arroyo", 2).EnterText("300");
        }


        public void AddNewTask3()

        {
            AddBtn.WaitUntil();

            AddBtn.Clicks();

            AddNewTask.Clicks();

            TaskName.WaitUntil();

            TaskName.EnterText("Unplanned Task 1");

            TaskTypeParent("Office Tasks").Clicks();

            TaskTypeChild("Discipline").Clicks(); WaitforIt(Properties.VeryInactivePhase); //WaitforIt(Properties.VeryInactivePhase)

            Complexity.SelectIndex(1); WaitforIt(Properties.VeryInactivePhase);

            UCodeNewTask.WaitUntil();

            UCodeNewTask.Clicks(); WaitforIt(Properties.VeryInactivePhase);

            UCommentNewTask.EnterText("Unplanned"); WaitforIt(Properties.InactivePhase);

            SaveTask.WaitUntil();

            SaveTask.Clicks(); WaitforIt(Properties.InactivePhase);

            AddBtn.WaitUntil();
        }


        public void AddExTask3()

        {
            AddBtn.WaitUntil();

            AddBtn.Clicks();

            AddExistingTask.Clicks(); WaitforIt(Properties.VeryInactivePhase);

            SelectTask(6).Clicks();

            TaskComment.EnterText("Existing Task 2");

            UCodeExTask.Clicks();

            AddExTask.WaitUntil();

            AddExTask.Clicks();

            AddBtn.WaitUntil();
        }



        public void AddFavoriteTask3()

        {
            AddBtn.WaitUntil();

            AddBtn.Clicks();

            AddFavTask.Clicks(); WaitforIt(Properties.InactivePhase);

            SelectTask(5).WaitUntil();

            SelectTask(5).Clicks();

            UCodeFavTask.Clicks();

            UCommentFavTask.EnterText("!2Q");

            UFavTaskSave.Clicks();

        }


        public void ResourceAdd3()

        {
            TaskElementUnplanned("Unplanned").WaitUntil(); TaskElementUnplanned("Unplanned").Clicks();

            AddResource.WaitUntil();

            AddResource.Clicks();

            ResourceType.WaitUntil();

            ResourceType.SelectDropdown("eMOSUser");

            SelectResource("Barger").WaitUntil();

            SelectResource("Barger").Clicks();

            ResourceAdded.Clicks();

        }


        public void BarrierAdd()

        {
            TaskElementUnplanned("Unplanned").WaitUntil(); TaskElementUnplanned("Unplanned").Clicks();

            AddBarrier.Clicks();

            SelectBarrier("Lot Traffic").WaitUntil();

            SelectBarrier("Lot Traffic").Clicks();

            BarrierComment.EnterText("!2Qb");

            SaveBarrier.Clicks();
        }



        public void EnterVolume3()

        {
            VolumeEntry(0.0014, "Barger", 0).WaitUntil();

            VolumeEntry(0.0014, "Barger", 0).EnterText("700");
        }


        public void BarrierAdd2()

        {
            TaskElementUnplanned("Unplanned").WaitUntil(); TaskElementUnplanned("Unplanned").Clicks();

            AddBarrier.Clicks();

            SelectBarrier("Lot Traffic").WaitUntil();

            SelectBarrier("Lot Traffic").Clicks();

            BarrierComment.EnterText("!23Q");

            SaveBarrier.Clicks();
        }



        public void LogSave()

        {
            SaveButton("Save").WaitUntil(); SaveButton("Save").Clicks();

            SavedElement.WaitUntil();

            Assert.That(SavedElement, Is.Not.Null);


        }


        public void CheckTimeCalc4()

        {
            WaitforIt(Properties.InactivePhase);

            Assert.Multiple((() =>
                {
                    Assert.That(TotalActT1.Text.Equals("1.5"));

                    Assert.That(TotalActV1.Text.Equals("1200"));
                }

            ));

        }


        public void BarrierRemove()

        {
            TaskElementUnplanned("Breakdowns").WaitUntil(); TaskElementUnplanned("Breakdowns").Clicks();

            RemoveTask.Clicks();

            BarrierElement("!23Q").WaitUntil();

            BarrierElement("!23Q").Clicks();

            RemoveBarrier.Clicks();

            SaveButton("Save").WaitUntil();

            SaveButton("Save").Clicks();

            AddBtn.WaitUntil();

        }


        public void AddNewTask4()

        {
            AddBtn.WaitUntil(); AddBtn.Clicks();

            AddNewTask.Clicks();

            TaskName.WaitUntil();

            TaskName.EnterText("Unplanned Task 2");

            TaskTypeParent("Office Tasks").Clicks();

            TaskTypeChild("Discipline").Clicks(); WaitforIt(Properties.VeryInactivePhase);

            Complexity.SelectIndex(1); WaitforIt(Properties.InactivePhase);

            UCodeNewTask.WaitUntil();

            UCodeNewTask.Clicks(); WaitforIt(Properties.VeryInactivePhase);

            UCommentNewTask.EnterText("Unplanned2"); WaitforIt(Properties.InactivePhase);

            SaveTask.WaitUntil();

            SaveTask.Clicks(); WaitforIt(Properties.InactivePhase);

            AddBtn.WaitUntil();
        }



        public void AddExTask4()

        {
            AddBtn.WaitUntil(); AddBtn.Clicks();

            AddExistingTask.Clicks(); WaitforIt(Properties.VeryInactivePhase);

            SelectTask(7).Clicks();

            UnplanCode.Clicks();

            TaskComment.EnterText("Existing Task 3");

            AddExTask.WaitUntil();

            AddExTask.Clicks();

            AddBtn.WaitUntil();

        }


        public void AddFavoriteTask4()

        {
            AddBtn.WaitUntil(); AddBtn.Clicks();

            AddFavTask.Clicks(); WaitforIt(Properties.InactivePhase);

            SelectTask(12).Clicks();

            UnplanCode.Clicks();

            FavComment.EnterText("Favorite Task 3");

            FavAdded.Clicks();
        }


        public void ResourceAdd4()

        {
            TaskElementUnplanned("Idle").WaitUntil(); TaskElementUnplanned("Idle").Clicks();

            AddResource.Clicks();

            ResourceType.WaitUntil();

            ResourceType.SelectDropdown("eMOSUser");

            SelectResource("Baker").WaitUntil();

            SelectResource("Baker").Clicks();

            ResourceAdded.Clicks();
        }



        public void BarrierAdd3()

        {
            ResourceUnplanned("Unplanned Task 1").WaitUntil(); ResourceUnplanned("Unplanned Task 1").Clicks();

            AddBarrier.Clicks();

            SelectBarrier("Lot Traffic").WaitUntil();

            SelectBarrier("Lot Traffic").Clicks();

            BarrierComment.EnterText("!2Qa");

            SaveBarrier.Clicks();

            AddBtn.WaitUntil();

            TaskElementUnplanned2("Idle").Clicks();

            AddBarrier.Clicks();

            SelectBarrier("Bus Not").Clicks();

            BarrierComment.EnterText("!2Qc");

            SaveBarrier.Clicks();

            AddBtn.WaitUntil();
        }


        public void EnterVolume4()

        {
            VolumeEntry(0.0014, "!2Qa", 0).WaitUntil();

            VolumeEntry(0.0014, "!2Qa", 0).EnterText("200");

            VolumeEntry(0.0014, "!2Qb", 0).WaitUntil();

            VolumeEntry(0.0014, "!2Qb", 0).EnterText("100");

            VolumeEntry(0.01, "Baker", 1).WaitUntil();

            VolumeEntry(0.01, "Baker", 1).EnterText("10");

            VolumeEntry(0.01, "!2Qc", 1).WaitUntil();

            VolumeEntry(0.01, "!2Qc", 1).EnterText("5");
        }


        public void LogApprove()

        {
            WaitforIt(Properties.InactivePhase); SaveButton("Approve Log").WaitUntil();

            SaveButton("Approve Log").Clicks();

            SavedElement.WaitUntil();

            Assert.That(SavedElement, Is.Not.Null);

            Assert.That(PlanStatus("Log Approved").Displayed);

            LogOut.Clicks(); WaitforIt(Properties.InactivePhase);

            Login("automationuser3", "eMos123!");

            RePlanLog(); WaitforIt(Properties.InactivePhase);
        }


        public void CheckTimeCalc5()
        {
            SaveButton("Undo").Clicks(); WaitforIt(Properties.InactivePhase);

            SaveButton("Reject").Clicks(); WaitforIt(Properties.InactivePhase);

            RejectLog("Reject").Clicks(); WaitforIt(Properties.InactivePhase);

            VolumeEntry(0.01, "Baker", 1).WaitUntil(); VolumeEntry(0.01, "Baker", 1).ClearText();

            VolumeEntry(0.01, "Baker", 1).EnterText("100");

            VolumeEntry(0.01, "!2Qc", 1).WaitUntil(); VolumeEntry(0.01, "!2Qc", 1).ClearText();

            VolumeEntry(0.01, "!2Qc", 1).EnterText("50");

            LogApprove();

            Assert.Multiple((() =>
                {
                    Assert.That(TotalActT1.Text.Equals("2"));

                    Assert.That(TotalActV1.Text.Equals("1300"));
                }

            ));
        }


        /* public void AddActual()

         {
             AddBtn.WaitUntil();

             AddBtn.Clicks();

             AddActuals.WaitUntil();

             AddActuals.Clicks();

             AddtoDSC.WaitUntil();

             AddtoDSC.Clicks();
         }*/



        public void ViewChecking()

        {
            TaskResourceView.WaitUntil(); TaskResourceView.SelectDropdown("Resource");

            VolumeTimePerformance.WaitUntil();

            VolumeTimePerformance.SelectDropdown("Volume");

            VolumeTimePerformance.WaitUntil(); WaitforIt(Properties.InactivePhase);


            Assert.Multiple((() =>
                {
                    Assert.That(ResourceVolumePerformance(0).Text.Contains("200%"));

                    Assert.That(ResourceVolumePerformance(2).Text.Contains("200%"));

                    Assert.That(ResourceVolumePerformance(3).Text.Contains("200%"));

                    Assert.That(ResourceVolumePerformance(4).Text.Contains("200%"));

                    Assert.That(ResourceVolumePerformance(5).Text.Contains("100%"));

                    Assert.That(ResourceVolumePerformance(9).Text.Contains("300%"));

                    Assert.That(ResourceVolumePerformance(10).Text.Contains("300%"));

                    Assert.That(ResourceVolumePerformance(11).Text.Contains("200%"));
                    
                    Assert.That(ResourceVolumePerformance(12).Text.Contains("200%"));

                    Assert.That(ResourceVolumeTotalP.Text.Contains("225%"));

                    Assert.That(ResourceVolumeCollumnP1.Text.Contains("700"));
                }

            ));


            VolumeTimePerformance.WaitUntil();

            VolumeTimePerformance.SelectDropdown("Time");

            VolumeTimePerformance.WaitUntil(); WaitforIt(Properties.InactivePhase);


            Assert.Multiple((() =>
                {
                    Assert.That(TotalPLanT1.Text.Contains("2"));

                    Assert.That(TotalPlanV1.Text.Contains("1600"));

                    Assert.That(TotalActT1.Text.Contains("2"));

                    Assert.That(TotalActV1.Text.Contains("1300"));

                    Assert.That(ResourceVolumeCollumnP1.Text.Contains("1"));

                    Assert.That(ResourceVolumeTotalP.Text.Contains("225%"));
                }

            ));


            VolumeTimePerformance.WaitUntil();

            VolumeTimePerformance.SelectDropdown("Performance");

            VolumeTimePerformance.WaitUntil(); WaitforIt(Properties.InactivePhase);

            Assert.Multiple((() =>
                {
                    Assert.That(ResourcePerformanceTa.Text.Contains("4.5/2 225%"));

                    Assert.That(ResourcePerformanceT0.Text.Contains("1/0.5 200%"));

                }

            ));


            TaskResourceView.WaitUntil();

            TaskResourceView.SelectDropdown("Task");

            VolumeTimePerformance.WaitUntil();

            VolumeTimePerformance.SelectDropdown("Time");

            VolumeTimePerformance.WaitUntil(); WaitforIt(Properties.InactivePhase);


            Assert.Multiple((() =>
                {
                    Assert.That(TotalPLanT1.Text.Contains("2"));

                    Assert.That(TotalPlanV1.Text.Contains("1600"));

                    Assert.That(TotalActT1.Text.Contains("2"));

                    Assert.That(TotalActV1.Text.Contains("1300"));

                    Assert.That(ResourceVolumeCollumnP1.Text.Contains("1"));

                    Assert.That(ResourceVolumeTotalP.Text.Contains("225%"));

                }

            ));


            VolumeTimePerformance.WaitUntil();

            VolumeTimePerformance.SelectDropdown("Performance");

            VolumeTimePerformance.WaitUntil(); WaitforIt(Properties.InactivePhase);


            Assert.Multiple((() =>
                {
                    Assert.That(ResourcePerformanceT0.Text.Contains("1/0.5 200%"));

                }

            ));


        }



        public void CopyPlan()
        {
            WaitforIt(Properties.InactivePhase); TaskResourceView.WaitUntil();

            TaskResourceView.SelectDropdown("Task");

            VolumeTimePerformance.WaitUntil();

            VolumeTimePerformance.SelectDropdown("Volume");

            VolumeTimePerformance.WaitUntil();

            SelectDateDropdown.SelectIndex(3);

            AddBtn.Clicks();

            ExistingPlan.WaitUntil();

            ExistingPlan.Clicks();

            CopyPlanClick.WaitUntil();

            CopyPlanClick.Clicks();

            AddBtn.WaitUntil();

            Assert.Multiple((() =>
                {
                    Assert.That(TotalPLanT1.Text.Equals("2"));

                    Assert.That(TotalPlanV1.Text.Equals("1600"));

                    Assert.That(SavedElement, Is.Not.Null);
                }

            ));
        }
        
        
    }
}
