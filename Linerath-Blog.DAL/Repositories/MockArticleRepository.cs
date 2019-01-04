using System;
using System.Linq;
using System.Collections.Generic;
using Linerath_Blog.DAL.Entities;
using Linerath_Blog.DAL.Interfaces;

namespace Linerath_Blog.DAL.Repositories
{
    public class MockArticleRepository : IArticleRepository
    {
        private List<Subject> subjects = new List<Subject>();
        private List<Article> articles = new List<Article>();

        public MockArticleRepository()
        {
            // subjects.
            subjects.Add(new Subject { Id = 0, Name = "Жизнь" });
            subjects.Add(new Subject { Id = 1, Name = "За Нерзула" });

            // articles.
            articles.Add(new Article
            {
                Id = 0,
                Title = "Welcome",
                Body = "To my in-development blog. I'm so excited about that idea.\n\nlox",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });
            articles.Add(new Article
            {
                Id = 1,
                Title = "Eyeless",
                Body = "Insane - Am I the only motherfucker with a brain?\n"
                       + "I'm hearing voices but all they do is complain\n"
                       + "How many times have you wanted to kill\n"
                       + "Everything and everyone - Say you'll do it but never will\n"
                       + "You can't see California without Marlon Brando's eyes\n\n"
                       + "Can't see California without Marlon Brando's eyes\n"
                       + "You can't see California without Marlon Brando's eyes\n",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });
            articles.Add(new Article
            {
                Id = 2,
                Title = "Кликбейтный заголовок!",
                Body = "Заголовок кликбейтный, а содержания нет. Фить Ха!.",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });
            articles.Add(new Article
            {
                Id = 3,
                Title = "Lorem ipsum",
                Body =  "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nisi est sit amet facilisis magna. Consectetur lorem donec massa sapien faucibus et. Egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices. Duis at tellus at urna condimentum mattis pellentesque. Tellus molestie nunc non blandit massa enim nec dui nunc. In vitae turpis massa sed. Mus mauris vitae ultricies leo integer malesuada nunc vel risus. Egestas quis ipsum suspendisse ultrices gravida dictum. Est ullamcorper eget nulla facilisi etiam. Vel eros donec ac odio tempor orci dapibus. Nec tincidunt praesent semper feugiat nibh sed. Amet consectetur adipiscing elit pellentesque habitant morbi. Malesuada fames ac turpis egestas. Volutpat est velit egestas dui id. Pulvinar elementum integer enim neque volutpat. Fames ac turpis egestas maecenas pharetra convallis.\n\n"
                        + "Enim nulla aliquet porttitor lacus luctus accumsan tortor. Lectus nulla at volutpat diam. Convallis aenean et tortor at risus. Sit amet dictum sit amet justo donec enim diam vulputate. Dignissim cras tincidunt lobortis feugiat vivamus at augue. Scelerisque varius morbi enim nunc faucibus a pellentesque. Massa vitae tortor condimentum lacinia quis vel eros. Elementum nisi quis eleifend quam adipiscing vitae proin. Netus et malesuada fames ac turpis egestas sed tempus. Gravida cum sociis natoque penatibus. Quis ipsum suspendisse ultrices gravida dictum fusce ut placerat orci. Risus at ultrices mi tempus imperdiet nulla. Et molestie ac feugiat sed lectus vestibulum mattis ullamcorper. Augue eget arcu dictum varius duis at consectetur lorem. Ipsum suspendisse ultrices gravida dictum fusce ut placerat.\n\n"
                        + "Proin nibh nisl condimentum id venenatis. Tellus pellentesque eu tincidunt tortor aliquam nulla facilisi cras fermentum. Mattis molestie a iaculis at. Convallis convallis tellus id interdum velit laoreet id donec ultrices. In vitae turpis massa sed elementum. Sagittis orci a scelerisque purus semper eget. Egestas dui id ornare arcu odio. Aliquam eleifend mi in nulla posuere sollicitudin aliquam. Dictum varius duis at consectetur lorem donec. Faucibus purus in massa tempor. Morbi tristique senectus et netus et malesuada fames ac turpis. Sed vulputate odio ut enim blandit. Rutrum quisque non tellus orci ac.\n\n"
                        + "Tellus pellentesque eu tincidunt tortor. Placerat duis ultricies lacus sed turpis. Arcu ac tortor dignissim convallis aenean et tortor. Lectus quam id leo in vitae turpis massa sed elementum. Ultrices vitae auctor eu augue ut lectus arcu bibendum at. Maecenas volutpat blandit aliquam etiam erat velit scelerisque in dictum. Id velit ut tortor pretium. Arcu bibendum at varius vel pharetra. Ullamcorper velit sed ullamcorper morbi. Porttitor rhoncus dolor purus non. Porta non pulvinar neque laoreet suspendisse interdum consectetur libero. Proin sagittis nisl rhoncus mattis rhoncus urna neque. Consequat interdum varius sit amet mattis vulputate enim nulla. Arcu risus quis varius quam quisque id. Molestie at elementum eu facilisis sed odio morbi quis. Donec ultrices tincidunt arcu non. Dui ut ornare lectus sit amet est placerat in. Blandit cursus risus at ultrices mi tempus. Gravida in fermentum et sollicitudin ac orci phasellus egestas. Montes nascetur ridiculus mus mauris vitae ultricies.\n\n"
                        + "Dictumst quisque sagittis purus sit amet. Viverra ipsum nunc aliquet bibendum. Cursus turpis massa tincidunt dui ut ornare lectus sit amet. Habitant morbi tristique senectus et. Cras ornare arcu dui vivamus arcu felis bibendum ut tristique. Fringilla urna porttitor rhoncus dolor purus. Commodo elit at imperdiet dui accumsan sit amet. Quam adipiscing vitae proin sagittis nisl rhoncus. Scelerisque mauris pellentesque pulvinar pellentesque habitant morbi tristique senectus et. Sit amet mauris commodo quis imperdiet massa tincidunt. Pellentesque elit eget gravida cum. Arcu dui vivamus arcu felis bibendum ut tristique. Fermentum et sollicitudin ac orci phasellus egestas. Eu tincidunt tortor aliquam nulla facilisi cras fermentum. Malesuada fames ac turpis egestas maecenas pharetra convallis.\n\n"
                        + "Diam sit amet nisl suscipit adipiscing bibendum. Nunc sed velit dignissim sodales ut eu sem integer vitae. Elit ullamcorper dignissim cras tincidunt lobortis feugiat vivamus at augue. Nam aliquam sem et tortor consequat id porta nibh. Id donec ultrices tincidunt arcu non sodales neque sodales. Ullamcorper sit amet risus nullam eget felis eget. Laoreet suspendisse interdum consectetur libero id faucibus nisl tincidunt. Commodo viverra maecenas accumsan lacus vel facilisis volutpat. Sed enim ut sem viverra aliquet eget sit amet tellus. Facilisis leo vel fringilla est ullamcorper eget nulla facilisi etiam.\n\n"
                        + "Vel pretium lectus quam id. Enim diam vulputate ut pharetra. Elementum integer enim neque volutpat. Id cursus metus aliquam eleifend mi. Dolor sit amet consectetur adipiscing. Pellentesque elit eget gravida cum sociis natoque. Sit amet volutpat consequat mauris nunc congue. Platea dictumst vestibulum rhoncus est pellentesque elit ullamcorper. Sagittis eu volutpat odio facilisis mauris sit amet massa vitae. Lacinia at quis risus sed vulputate. Nibh sit amet commodo nulla facilisi. Justo nec ultrices dui sapien eget mi proin. Amet nisl suscipit adipiscing bibendum est ultricies integer quis auctor. Augue eget arcu dictum varius. Cras tincidunt lobortis feugiat vivamus.\n\n"
                        + "Eget duis at tellus at urna condimentum mattis. Ut ornare lectus sit amet est placerat in egestas. Enim blandit volutpat maecenas volutpat blandit aliquam. Eget sit amet tellus cras. Dictum varius duis at consectetur lorem donec massa sapien. Diam volutpat commodo sed egestas egestas fringilla. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo. At consectetur lorem donec massa. Massa tempor nec feugiat nisl. Viverra suspendisse potenti nullam ac. Sed viverra tellus in hac. Diam volutpat commodo sed egestas. Semper quis lectus nulla at volutpat diam ut venenatis. Rhoncus aenean vel elit scelerisque mauris pellentesque pulvinar. Ante in nibh mauris cursus mattis molestie a iaculis. Non pulvinar neque laoreet suspendisse interdum consectetur libero. Euismod lacinia at quis risus sed vulputate odio ut enim. Tempor nec feugiat nisl pretium fusce. Eget nunc lobortis mattis aliquam faucibus purus. Dignissim diam quis enim lobortis scelerisque fermentum dui faucibus.\n\n"
                        + "Leo in vitae turpis massa sed elementum tempus egestas sed. Purus non enim praesent elementum facilisis leo vel fringilla est. Sed vulputate mi sit amet mauris. Tincidunt augue interdum velit euismod in pellentesque massa placerat duis. Nam libero justo laoreet sit. Natoque penatibus et magnis dis parturient montes. Fringilla phasellus faucibus scelerisque eleifend. Porttitor eget dolor morbi non arcu risus quis varius quam. Ridiculus mus mauris vitae ultricies. Adipiscing vitae proin sagittis nisl rhoncus. Eget duis at tellus at. Purus semper eget duis at. Et egestas quis ipsum suspendisse. Odio tempor orci dapibus ultrices in iaculis nunc. Porta non pulvinar neque laoreet suspendisse interdum consectetur libero id. Venenatis lectus magna fringilla urna porttitor. Tellus in hac habitasse platea dictumst vestibulum rhoncus est. Pellentesque diam volutpat commodo sed egestas egestas fringilla phasellus faucibus. Id eu nisl nunc mi ipsum faucibus.\n\n"
                        + "Morbi non arcu risus quis varius quam. In nisl nisi scelerisque eu ultrices vitae auctor eu. Ultrices tincidunt arcu non sodales neque sodales ut etiam. Magna fringilla urna porttitor rhoncus dolor purus non enim praesent. Suscipit tellus mauris a diam maecenas. Volutpat sed cras ornare arcu dui vivamus arcu felis. Arcu odio ut sem nulla pharetra diam. Tellus cras adipiscing enim eu. Eget mi proin sed libero. Molestie at elementum eu facilisis sed odio morbi quis commodo. Arcu dui vivamus arcu felis. Sit amet mauris commodo quis imperdiet massa tincidunt.\n\n"
                        + "Ante metus dictum at tempor commodo. Tincidunt arcu non sodales neque. Tincidunt tortor aliquam nulla facilisi cras fermentum odio eu. Tincidunt tortor aliquam nulla facilisi cras fermentum odio eu feugiat. Aliquet risus feugiat in ante metus. Lacus sed turpis tincidunt id aliquet risus. Laoreet non curabitur gravida arcu ac tortor dignissim convallis. Tellus integer feugiat scelerisque varius morbi enim nunc. Donec adipiscing tristique risus nec. Purus in mollis nunc sed id semper risus in.\n\n"
                        + "Amet justo donec enim diam. Non blandit massa enim nec dui nunc mattis enim ut. Nibh mauris cursus mattis molestie. Consequat ac felis donec et odio pellentesque. Sed risus pretium quam vulputate dignissim suspendisse in. Dis parturient montes nascetur ridiculus. Id aliquet lectus proin nibh nisl condimentum id venenatis. At lectus urna duis convallis convallis tellus id. Dolor sed viverra ipsum nunc aliquet bibendum. Parturient montes nascetur ridiculus mus mauris. Mi quis hendrerit dolor magna eget est lorem.\n\n"
                        + "Nec ultrices dui sapien eget mi proin sed. Amet consectetur adipiscing elit pellentesque habitant. Egestas sed sed risus pretium. Auctor elit sed vulputate mi. Sodales neque sodales ut etiam sit amet nisl. Lobortis elementum nibh tellus molestie nunc non blandit massa. Eget mi proin sed libero enim sed faucibus turpis. Non diam phasellus vestibulum lorem sed risus ultricies tristique nulla. Mauris pellentesque pulvinar pellentesque habitant morbi tristique. Morbi tincidunt ornare massa eget egestas. Volutpat est velit egestas dui id ornare. Condimentum vitae sapien pellentesque habitant.\n\n"
                        + "Malesuada pellentesque elit eget gravida cum sociis natoque penatibus. Vel pharetra vel turpis nunc eget lorem dolor. Morbi tristique senectus et netus et malesuada fames ac. Amet purus gravida quis blandit turpis cursus in hac habitasse. Nam at lectus urna duis convallis convallis tellus id. Vulputate odio ut enim blandit volutpat maecenas. Eget dolor morbi non arcu risus quis. Venenatis tellus in metus vulputate eu scelerisque. Nisl rhoncus mattis rhoncus urna neque viverra justo. Sagittis id consectetur purus ut faucibus pulvinar elementum integer enim. Nisl rhoncus mattis rhoncus urna neque viverra justo. Justo donec enim diam vulputate ut. Nisi lacus sed viverra tellus in hac habitasse platea. Interdum varius sit amet mattis vulputate enim nulla. Massa enim nec dui nunc mattis enim ut. Et netus et malesuada fames ac turpis. Morbi tempus iaculis urna id volutpat lacus laoreet. Donec adipiscing tristique risus nec feugiat in fermentum posuere urna. Iaculis at erat pellentesque adipiscing commodo elit at imperdiet dui. Eget egestas purus viverra accumsan in nisl nisi scelerisque eu.\n\n"
                        + "Aliquet bibendum enim facilisis gravida. Mauris ultrices eros in cursus turpis. Accumsan sit amet nulla facilisi morbi tempus. Quam pellentesque nec nam aliquam sem et tortor. Amet facilisis magna etiam tempor orci eu lobortis elementum nibh. Lectus proin nibh nisl condimentum id venenatis a condimentum vitae. Mi sit amet mauris commodo quis imperdiet. Elit ut aliquam purus sit amet. Congue mauris rhoncus aenean vel. Scelerisque in dictum non consectetur. Morbi tincidunt augue interdum velit euismod in pellentesque massa. Sem viverra aliquet eget sit. Quis hendrerit dolor magna eget. Senectus et netus et malesuada fames. Vel quam elementum pulvinar etiam non quam lacus suspendisse. Sed elementum tempus egestas sed sed risus pretium. Luctus accumsan tortor posuere ac. Aenean sed adipiscing diam donec adipiscing tristique risus nec feugiat. Tellus elementum sagittis vitae et.",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });
            articles.Add(new Article
            {
                Id = 4,
                Title = "Не люблю людей, которые спокойно меняют свое мнение на противоположное.",
                Body = "Да. От таких людей можно ожидать чего угодно. Сегодня они говорят тебе, чтобы ненавидят, например, ходить по клубам, а завтра уже ставят перед фактом, что им захотелось его посетить и они не видят ничего плохого в этом.",
                CreationDate = DateTime.Now,
                Subjects = subjects,
            });
        }

        public List<Article> GetAllArticles()
        {
            return articles;
        }

        //public List<Article> GetArticlesBySubject(Subject subject)
        //{
        //}

        public Article GetArticleById(int id)
        {
            return articles.FirstOrDefault(x => x.Id == id);
        }
    }
}
