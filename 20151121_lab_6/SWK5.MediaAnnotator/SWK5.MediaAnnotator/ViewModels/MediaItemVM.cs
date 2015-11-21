using Swk5.MediaAnnotator.BL;
using Swk5.MediaAnnotator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWK5.MediaAnnotator.ViewModels
{
    public class MediaItemVM : ViewModelBase
    {
        private MediaItem item;

        public ICommand SaveCommand { get; set; }

        public string Name
        {
            get
            {
                return this.item.Name;
            }
            set
            {
                this.item.Name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.item.Url;
            }
            set
            {
                this.item.Url = value;
            }
        }

        public string Annotation
        {
            get
            {
                return this.item.Annotation;
            }
            set
            {
                this.item.Annotation = value;
                RaisePropertyChangedEvent();
            }
        }

        public MediaItemVM(MediaItem item, IMediaManager mediaManager)
        {
            this.item = item;
            this.SaveCommand = new RelayCommand(o => { mediaManager.UpdateAnnotation(this.item); });
        }
    }

}
