using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace eMOS
{
    class PageObjectPlanLog
    {
        
        public PageObjectPlanLog()
        {
            RetryingElementLocator retry = new RetryingElementLocator(Properties.Driver, TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(1));

            PageFactory.InitElements(retry.SearchContext, this);
        }

       
        //Login Components

        [FindsBy (How = How.CssSelector, Using = "input#LoginUser_UserName")]

        public IWebElement UserName { get; set; }


        [FindsBy (How = How.CssSelector, Using = "input#LoginUser_Password")]

        public IWebElement Password { get; set; }


        [FindsBy (How = How.CssSelector, Using = "input#LoginUser_LoginButton")]

        public IWebElement LoginBtn { get; set; }


        //PlanLog Tab

        [FindsBy(How = How.XPath, Using = "//select [contains (@name, 'ddPlanPeriod')] /option [@selected = 'selected']")]

        public IWebElement Date { get; set; }

        [FindsBy (How = How.CssSelector, Using = "a[href*='PlanLog']")]

        public IWebElement PlanLogTab { get; set; }


        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddDirectorate")]

        public IWebElement DprtmntSelect { get; set; }


        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddTeam")] 

        public IWebElement TeamSelect { get; set; }


        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddProfile")]

        public IWebElement UserSelect { get; set; }


        [FindsBy (How = How.Id, Using = "iPlanLogCalendar")]

        public IWebElement Calender { get; set; }


        [FindsBy (How = How.XPath, Using = "//a[@title='Prev']")]

        public IWebElement PrevDate { get; set; }


        public IWebElement SelectDate(int index)
        {
            return Properties.Driver.FindElement(By.XPath($"//table [contains (@class, 'ui-datepicker')] //td /a[text()= '{index}']"));
        }

        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddPlanPeriod")]

        public IWebElement WhatstheDate { get; set; }

        public IWebElement PlanStatus(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//span [contains (@id, 'lblStatus')] [contains (text(), '{name}')]"));
        }



        //PlanLog Componenets

        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnAddMenu")]

        public IWebElement AddBtn { get; set; }

        [FindsBy (How = How.Id, Using = "liAddNewTask")]

        public IWebElement AddNewTask { get; set; }

        [FindsBy(How = How.Id, Using = "liAddTask")]

        public IWebElement AddExistingTask { get; set; }

        [FindsBy(How = How.Id, Using = "liAddFav")]

        public IWebElement AddFavTask { get; set; }

        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_titleTextBox")]

        public IWebElement TaskName { get; set; }



        //Task Type Selection

        public IWebElement TaskTypeParent(string name)

        {
            return Properties.Driver.FindElement(By.XPath($"//img [contains (@alt, '{name}')]"));
        }

        public IWebElement TaskTypeChild(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//a[contains (text(),'{name}')]"));
        }




        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_reTextBox")] 

        public IWebElement Standard { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@id='ctl00_ContentPlaceHolder1_complexityDropDownList']")]

        public IWebElement Complexity { get; set; }

        [FindsBy (How = How.XPath, Using = "//input[contains(@id,'Button2')][@value='Save']")]

        public IWebElement SaveTask { get; set; }




        //favorite tasks

        public IWebElement SelectTask(int index)
        {
            return Properties.Driver.FindElement(By.XPath($"//div [{index}] [contains (@ng-repeat, 'fav')] //input [contains (@id, 'task-checkbox')]"));
        }


       

        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_addTaskAComments")]

        public IWebElement TaskComment { get; set; }

        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnAddTaskToPlan")]

        public IWebElement AddExTask { get; set; }

        [FindsBy (How = How.Id, Using = "ctl00_ContentPlaceHolder1_addTaskAComments")]

        public IWebElement FavComment { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnAddFavToPlan")]

        public IWebElement FavAdded { get; set; }


        
        //Tasks

        public IWebElement TaskLink(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//a [contains (text(), '{name}')]"));
        }


        
        //Fav RE

        public IWebElement ReUnits(int index, int reunit)
        {
            return Properties.Driver.FindElement(By.XPath($"//span [contains (@id, 'REUnits_{index}')] [contains (text(), '{reunit}')]"));
        }


        

        //Task Elements
        
        public IWebElement TaskElement(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//span[contains (@data-task-title, '{name}')] [@data-add-resource='1']"));
        }


        public IWebElement TaskElementUnplanned(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//span[contains (@data-task-title, '{name}')] [@data-remove-task='1']"));
        }


        public IWebElement BarrierElement(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//span[@data-barrier-comment='{name}']"));
        }

        public IWebElement ResourceUnplanned(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//span[@data-task-title='{name}'] [@data-add-resource]"));
        }
        
        public IWebElement TaskElementUnplanned2(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//span[contains (@data-task-title, '{name}')] [@data-remove-resource = '1']"));
        }


        //Volume Entries


        public IWebElement VolumeEntry(double re, string name, int index)
        {
            return Properties.Driver.FindElement(By.XPath($"//tr [contains (@data-re, '{re}')] //td [contains (text(), '{name}')] /following-sibling:: td [contains (@class, 'Period_{index}')] /input"));
        }
        
        


        //Calcultaions

        [FindsBy(How = How.XPath, Using = "//th[@id='ColTotal_P_T'][@class='TotalFooterPlan']")]

        public IWebElement TotalPLanT1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//th[@id='ColTotal_P_V'][@class='TotalFooterPlan']")]

        public IWebElement TotalPlanV1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//th[@id='ColTotal_A_T'][@class='TotalFooterPlan']")]

        public IWebElement TotalActT1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//th[@id='ColTotal_A_V'][@class='TotalFooterPlan']")]

        public IWebElement TotalActV1 { get; set; }


        //Resources

        [FindsBy (How = How.Id, Using = "liAddResource")]

        public IWebElement AddResource { get; set; }
        

        [FindsBy (How = How.Id, Using = "ddlResource_ResourceTypeID")]

        public IWebElement ResourceType { get; set; }


        public IWebElement SelectResource(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//span[contains (text(), '{name}')]"));
        }

        [FindsBy(How = How.Id, Using = "btnAddResource")] 

        public IWebElement ResourceAdded { get; set; }



        //Save, Approve

        public IWebElement SaveButton(string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//input [contains (@class, 'btn sm')]  [contains (@value, '{name}')]"));
        }

        public IWebElement RejectLog (string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//input [@class = 'btn'] [contains (@value, '{name}')]"));
        }


        [FindsBy(How = How.CssSelector, Using = "span[id='PlanMessageLabel']")]

        public IWebElement SavedElement { get; set; }


        public IWebElement Resource(double index, string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//tr [contains (@data-re, '{index}')] //td [contains (text(), '{name}')] /preceding-sibling:: td [contains (@id, 'actionCell')] /span"));
        }

        [FindsBy(How = How.Id, Using = "liRemoveResource")]

        public IWebElement RemoveResource { get; set; }


        [FindsBy(How = How.Id, Using = "liRemoveTask")]

        public IWebElement RemoveTask { get; set; }

        



        [FindsBy(How = How.XPath, Using = "//a[text()='A-Other']")]

        public IWebElement UCodeNewTask { get; set; }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_unplannedCommentsTextBox")]

        public IWebElement UCommentNewTask { get; set; }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_Button2")]

        public IWebElement UNewTaskSave { get; set; }


        [FindsBy(How = How.Id, Using = "addUnplanCode_node_1")]

        public IWebElement UCodeExTask { get; set; }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_addTaskAComments")]

        public IWebElement UCommentNExTask { get; set; }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnAddTaskToPlan")]

        public IWebElement UExTaskSave { get; set; }


        [FindsBy(How = How.Id, Using = "addUnplanCode_node_1")]

        public IWebElement UCodeFavTask { get; set; }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_addTaskAComments")]

        public IWebElement UCommentFavTask { get; set; }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnAddFavToPlan")]

        public IWebElement UFavTaskSave { get; set; }

        [FindsBy(How = How.Id, Using = "liAddBarrier")]

        public IWebElement AddBarrier { get; set; }


        public IWebElement SelectBarrier( string name)
        {
            return Properties.Driver.FindElement(By.XPath($"//table //a [contains (text(), '{name}')]"));
        }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_barComment")]

        public IWebElement BarrierComment { get; set; }


        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnAddBarrier")]

        public IWebElement SaveBarrier { get; set; }


        [FindsBy(How = How.Id, Using = "liRemoveBarrier")]

        public IWebElement RemoveBarrier { get; set; }



        [FindsBy(How = How.Id, Using = "addUnplanCode_node_1")]

        public IWebElement UnplanCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@data-task-title='Unplanned Task 1'][@data-resource-id='18411']")]

        public IWebElement SelectResourceElement5 { get; set; }




        //Copy Existing Plan

        [FindsBy(How = How.XPath, Using = "//li[@id=\'liAddPlan\']")]

        public IWebElement ExistingPlan { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value=\'Copy Plan\']")]

        public IWebElement CopyPlanClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id=\'liAddActuals\']")]

        public IWebElement AddActuals { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id=\'ctl00_ContentPlaceHolder1_btnAddToDSC\']")]

        public IWebElement AddtoDsc { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@id, \'ddPlanPeriod\')]")]

        public IWebElement SelectDateDropdown { get; set; }



        //View

        [FindsBy(How = How.XPath, Using = "//select [contains (@name, \'Orientation\')]")]

        public IWebElement TaskResourceView { get; set; }

        [FindsBy(How = How.XPath, Using = "//select [contains (@name, \'Units\')]")]

        public IWebElement VolumeTimePerformance { get; set; }



        
        //Assertions in view
        
        public IWebElement ResourceVolumePerformance(int index)
        {
            return Properties.Driver.FindElement(By.XPath($"//th [contains (@id, 'PP_{index}')]"));
        }

       [FindsBy(How = How.XPath, Using = "//th [contains (@id, 'ColTotal_A_PP')]")]

        public IWebElement ResourceVolumeTotalP { get; set; }

        [FindsBy(How = How.XPath, Using = "//th [contains (@id, 'PeriodTotal_0_P')]")]

        public IWebElement ResourceVolumeCollumnP1 { get; set; }



        [FindsBy(How = How.XPath, Using = "//th [contains (@id, 'Total_A')]")]

        public IWebElement ResourcePerformanceTa { get; set; }

        [FindsBy(How = How.XPath, Using = "//th [contains (@id, 'Total_0')]")]

        public IWebElement ResourcePerformanceT0 { get; set; }


        [FindsBy(How = How.XPath, Using = "//a [text() = 'Log Out']")]

        public IWebElement LogOut { get; set; }


    }



}
