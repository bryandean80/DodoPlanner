#pragma checksum "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\ListView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d16dd5562af3a5aa2ae334a622cf9da4861d961"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace DodoPlanner.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\ListView.razor"
using DodoPlanner.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\ListView.razor"
using DodoPlanner.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\ListView.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\ListView.razor"
using DodoPlanner.Pages;

#line default
#line hidden
#nullable disable
    public partial class ListView : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "C:\Users\bbdea\Documents\DoDoPlanner\DodoPlanner\DodoPlanner\Components\ListView.razor"
       

    public string style { get; set; }

    private Guid theListId;

    [Parameter]
    public string ListId {
        get => theListId.ToString();
        set
        {
            theListId = Guid.Parse(value);
        }
    }


    string newtasktitle { get;
        set; }
    DateTime newduedate { get; set; }

    void AddNewTask()
    {
        var newTask = new task { title = newtasktitle, duedate = newduedate};
        tdlistservice.AddTask(newTask, theListId);
        newtasktitle = string.Empty;
        newduedate = DateTime.Now;
    }

    public void ToggleCompleted(string taskName)
    {
        tdlistservice.ToggleCompleted(theListId, taskName);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        newduedate = DateTime.Now;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private JsonFileTdListService tdlistservice { get; set; }
    }
}
#pragma warning restore 1591
