using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Loauto.Model
{
    class MenuItemModel
    {
        public string Name { get;  }

        private readonly Type _contentType;
        private readonly object _dataContext;
        private object _content;
        public object Content { get => _content; 
            set { 
                if(value == null)
                {
                    _content = CreateContent();
                }
                else
                {
                    _content = value; 
                }
            } 
        }


        public MenuItemModel(string name, Type contentType, object dataContext = null)
        {
            Name = name;
            _contentType = contentType;
            _dataContext = dataContext;
            Content = CreateContent();
        }

        private object CreateContent()
        {
            var content = Activator.CreateInstance(_contentType);
            if (content is FrameworkElement element)
            {
                element.DataContext = _dataContext;
            }

            return content;
        }


    }
}
