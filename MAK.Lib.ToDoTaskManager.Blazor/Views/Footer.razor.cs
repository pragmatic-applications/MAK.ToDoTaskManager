using System.Collections.Generic;
using System.Linq;

using Domain;

using Microsoft.AspNetCore.Components;

using PageFeatures;

namespace MAK.Lib.ToDoTaskManager.Blazor.Views
{
    public partial class Footer
    {
        [Parameter] public string BisName { get; set; }
        [Parameter] public List<PageLink> NavLinks { get; set; }

        public int FooterIndex { get; set; } = 2;

        private List<MenuData> bottomMenu;
        private List<MenuData> BottomMenu
        {
            get
            {
                if(this.bottomMenu is object)
                {
                    return this.bottomMenu;
                }

                this.bottomMenu = new List<MenuData>();
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                foreach(var type in assembly.GetExportedTypes().Where(type => type.CustomAttributes.Any(attr => attr.AttributeType.Equals(typeof(RouteAttribute)))))
                {
                    var urlAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(RouteAttribute))).First();
                    var titleAttr = type.CustomAttributes.Where(at => at.AttributeType.Equals(typeof(PageTitleAttribute))).FirstOrDefault();

                    if(titleAttr != null && titleAttr.ConstructorArguments[this.FooterIndex].Value.ToString() == "True")
                    {
                        var url = urlAttr.ConstructorArguments.First().Value.ToString().TrimStart('/');
                        var title = titleAttr?.ConstructorArguments.First().Value.ToString() ?? type.Name;

                        this.bottomMenu.Add(new MenuData { RelativeUrl = url, MenuTitle = title });
                    }
                }

                this.bottomMenu = this.bottomMenu.OrderBy(md => md.RelativeUrl).ToList<MenuData>();

                return this.bottomMenu;
            }
        }
    }
}
