#pragma checksum "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95f7af5266f62d0d5fd3877940ec426ce663e6cd"
// <auto-generated/>
#pragma warning disable 1591
namespace DodoPlanner.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
using DodoPlanner.Services;

#line default
#line hidden
#nullable disable
    public partial class Calendar : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "center");
            __builder.AddMarkupContent(1, "\r\n");
            __builder.AddMarkupContent(2, "<h3>Calendar</h3>\r\n");
            __builder.OpenElement(3, "table");
            __builder.AddAttribute(4, "class", "table table-bordered");
            __builder.AddMarkupContent(5, "\r\n    ");
            __builder.OpenElement(6, "thead");
            __builder.AddMarkupContent(7, "\r\n        ");
            __builder.OpenElement(8, "tr");
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.OpenElement(10, "th");
            __builder.AddAttribute(11, "colspan", "7");
            __builder.AddAttribute(12, "style", "text-align: center");
            __builder.AddContent(13, " ");
            __builder.AddContent(14, 
#nullable restore
#line 8 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                            month.Year.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n        ");
            __builder.OpenElement(17, "tr");
            __builder.AddMarkupContent(18, "\r\n            ");
            __builder.OpenElement(19, "th");
            __builder.AddAttribute(20, "style", "text-align:center");
            __builder.OpenElement(21, "a");
            __builder.AddAttribute(22, "class", "btn btn-outline-secondary");
            __builder.AddAttribute(23, "href", "/Calendar/" + (
#nullable restore
#line 11 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                                                                 previousMonth.Month

#line default
#line hidden
#nullable disable
            ) + "/" + (
#nullable restore
#line 11 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                                                                                      previousMonth.Year

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(24, 
#nullable restore
#line 11 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                                                                                                           previousMonth.ToString("MMMM")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n            ");
            __builder.OpenElement(26, "th");
            __builder.AddAttribute(27, "colspan", "5");
            __builder.AddAttribute(28, "style", "font-size: x-large; text-align: center;");
            __builder.AddContent(29, 
#nullable restore
#line 12 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                                             month.ToString("MMMM")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.OpenElement(31, "th");
            __builder.AddAttribute(32, "style", "text-align:center");
            __builder.OpenElement(33, "a");
            __builder.AddAttribute(34, "class", "btn btn-outline-secondary");
            __builder.AddAttribute(35, "href", " /Calendar/" + (
#nullable restore
#line 13 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                                                                  nextMonth.Month

#line default
#line hidden
#nullable disable
            ) + "/" + (
#nullable restore
#line 13 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                                                                                   nextMonth.Year

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(36, 
#nullable restore
#line 13 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                                                                                                                    nextMonth.ToString("MMMM")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n        ");
            __builder.OpenElement(39, "tr");
            __builder.AddMarkupContent(40, "\r\n");
#nullable restore
#line 16 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
             for(int i=0; i < 7; i++)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(41, "                ");
            __builder.OpenElement(42, "th");
            __builder.AddAttribute(43, "style", "text-align:center");
            __builder.AddContent(44, 
#nullable restore
#line 18 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                               Enum.Parse(typeof(DayOfWeek), i.ToString())

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(45, " ");
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n");
#nullable restore
#line 19 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(47, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n");
#nullable restore
#line 22 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
     while (!maxDayReached)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(50, "        ");
            __builder.OpenElement(51, "tr");
            __builder.AddMarkupContent(52, "\r\n");
#nullable restore
#line 25 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
             for(int i = 0; i < 7; i++)
            {
                if (i < (int)startingDay && dayOfMonthCounter == 0)
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(53, "                   <td></td>\r\n");
#nullable restore
#line 30 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                }
                else
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(54, "                    ");
            __builder.OpenElement(55, "td");
            __builder.AddAttribute(56, "style", "text-align: center;");
            __builder.AddMarkupContent(57, "\r\n                        ");
            __builder.AddContent(58, 
#nullable restore
#line 34 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                          ++dayOfMonthCounter

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(59, " <br>\r\n");
#nullable restore
#line 35 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                         foreach(var task in tdlistservice.GetTasksOnDate(month.AddDays(dayOfMonthCounter-1)))
                        {
                            if (!task.completed)
                            {
                                

#line default
#line hidden
#nullable disable
            __builder.AddContent(60, 
#nullable restore
#line 39 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                                 task.title

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(61, " <br>\r\n");
#nullable restore
#line 40 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                            }
                        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(62, "                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n");
#nullable restore
#line 43 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
                }

                if(dayOfMonthCounter == maxDay)
                {
                    maxDayReached = true;
                    break;
                }
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(64, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, " \r\n");
#nullable restore
#line 52 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(66, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\Calendar.razor"
       
    bool maxDayReached;
    DateTime month { get; set; }

    DateTime nextMonth
    {
        get
        {
            return month.AddMonths(1);
        }
    }

    DateTime previousMonth
    {
        get
        {
            return month.AddMonths(-1);
        }
    }

    DayOfWeek startingDay { get; set; }
    int maxDay { get; set; }
    int dayOfMonthCounter { get; set; }

    int monthNum;
    int yearNum;

    [Parameter]
    public string Month
    {
        get
        {
            return monthNum.ToString();
        }
        set
        {
            int val;
            bool result = int.TryParse(value, out val);
            if (result)
            {
                monthNum = val;
            }
            else
            {
                monthNum = DateTime.Now.Month;
            }
        }
    }

    [Parameter]
    public string Year
    {
        get
        {
            return yearNum.ToString();
        }
        set
        {
            int val;
            bool result = int.TryParse(value, out val);
            if (result)
            {
                yearNum = val;
            }
            else
            {
                yearNum = DateTime.Now.Year;
            }
        }
    }


    protected override void OnInitialized()
    {
        base.OnInitialized();

        month = new DateTime(yearNum, monthNum, 1);
        startingDay = month.DayOfWeek;
        maxDay = month.AddMonths(1).AddDays(-1).Day;
        maxDayReached = false;
        dayOfMonthCounter = 0;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private JsonFileTdListService tdlistservice { get; set; }
    }
}
#pragma warning restore 1591
