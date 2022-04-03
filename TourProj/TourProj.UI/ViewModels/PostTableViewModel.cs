using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourProj.BLL.DTO;
using TourProj.BLL.Services;
using TourProj.UI.Infrastructure;

namespace TourProj.UI.ViewModels
{
    class PostTableViewModel : BaseNotifyPropertyChanged
    {
        public PostService postService;
        public ObservableCollection<PostDTO> Posts { get; set; }

        private PostDTO selectedPost;
        public PostDTO SelectedPost
        {
            get => selectedPost;
            set
            {
                selectedPost = value;
                NotifyOfPopertyChanged();
            }
        }

        public PostTableViewModel(PostService service)
        {
            postService = service;
            Posts = new ObservableCollection<PostDTO>(postService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => postService.CreateOrUpdate(SelectedPost));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => postService.Delete(SelectedPost));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
