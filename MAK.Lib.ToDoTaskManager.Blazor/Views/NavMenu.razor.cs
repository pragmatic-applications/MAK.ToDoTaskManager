using System.Collections.Generic;
using System.Linq;

using Domain;

using Microsoft.AspNetCore.Components;

using PageFeatures;

namespace MAK.Lib.ToDoTaskManager.Blazor.Views
{
    public partial class NavMenu
    {
        [Parameter] public string BisName { get; set; }
        [Parameter] public List<PageLink> NavLinks { get; set; }

        private List<MenuData> topMenu;
        private List<MenuData> TopMenu
        {
            get
            {
                if(this.topMenu is object)
                {
                    return this.topMenu;
                }

                this.topMenu = new List<MenuData>();
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                foreach(var type in assembly.GetExportedTypes().Where(type => type.CustomAttributes.Any(attr => attr.AttributeType.Equals(typeof(RouteAttribute)))))
                {
                    var urlAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(RouteAttribute))).First();
                    var titleAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(PageTitleAttribute))).FirstOrDefault();

                    if(titleAttr != null && titleAttr.ConstructorArguments[1].Value.ToString() == "True")
                    {
                        var url = urlAttr.ConstructorArguments.First().Value.ToString().TrimStart('/');
                        var title = titleAttr?.ConstructorArguments.First().Value.ToString() ?? type.Name;

                        this.topMenu.Add(new MenuData { RelativeUrl = url, MenuTitle = title });
                    }
                }


                this.topMenu = this.topMenu.OrderBy(md => md.RelativeUrl).ToList<MenuData>();

                return this.topMenu;
            }
        }

        private List<MenuData> menu;
        private List<MenuData> Menu
        {
            get
            {
                if(this.menu is object)
                {
                    return this.menu;
                }

                this.menu = new List<MenuData>();
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                //foreach(var type in assembly.GetExportedTypes().Where(type => type.CustomAttributes.Any(attr => attr.AttributeType.Equals(typeof(RouteAttribute)))))
                //{
                //    var urlAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(RouteAttribute))).First();
                //    var titleAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(PageTitleAttribute))).FirstOrDefault();

                //    var url = urlAttr.ConstructorArguments.First().Value.ToString().TrimStart('/');
                //    var title = titleAttr?.ConstructorArguments.First().Value.ToString() ?? type.Name;
                //    this.menu.Add(new MenuData { RelativeUrl = url, MenuTitle = title });

                //}

                foreach(var type in assembly.GetExportedTypes().Where(type => type.CustomAttributes.Any(attr => attr.AttributeType.Equals(typeof(RouteAttribute)))))
                {
                    var urlAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(RouteAttribute))).First();
                    var titleAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(PageTitleAttribute))).FirstOrDefault();

                    if(titleAttr != null)
                    {
                        var url = urlAttr.ConstructorArguments.First().Value.ToString().TrimStart('/');
                        var title = titleAttr?.ConstructorArguments.First().Value.ToString() ?? type.Name;

                        this.menu.Add(new MenuData { RelativeUrl = url, MenuTitle = title });
                    }
                }


                this.menu = this.menu.OrderBy(md => md.RelativeUrl).ToList<MenuData>();

                return this.menu;
            }
        }
    }
}
