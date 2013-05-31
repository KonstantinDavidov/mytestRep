using FACCTS.Server.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Thinktecture.IdentityModel.Authorization.Mvc;
using Thinktecture.IdentityServer;

namespace FACCTS.Server.Areas.Admin
{
    //[Authorize]
    [ClaimsAuthorize(Constants.Actions.Administration, Constants.Resources.Configuration)]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CourtStaffController : Controller
    {
        /// <summary>
        /// Default action
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile(string userName)
        {
            ViewBag.userName = userName;
            EditUser editUser = new EditUser();

            if (!string.IsNullOrEmpty(userName))
            {
                MembershipUser user = Membership.GetUser(userName);

                if (user != null)
                {
                    editUser.UserName = user.UserName;
                    editUser.Email = user.Email;
                }
            }

            return View(editUser);
        }

        [HttpPost]
        public ActionResult Profile(EditUser user)
        {
            /*
             * save user info
             */

            MembershipUser mUser = Membership.GetUser(user.UserName);
            mUser.Email = user.Email;
            Membership.UpdateUser(mUser);

            return RedirectToAction("Profile", new { userName = user.UserName });
        }

        public ActionResult Availability(string userName)
        {
            ViewBag.userName = userName;

            return View();
        }

        public ActionResult UserRole(string userName)
        {
            ViewBag.userName = userName;

            return View();
        }

        public PartialViewResult UsersList(string userName)
        {
            MembershipUserCollection users = Membership.GetAllUsers();
            
            ViewBag.userName = userName;

            return PartialView(users);
        }

        public ActionResult CreateUser(string userName)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveUser(string userName)
        {
            /*
             * remove user's ext info
             */
            Membership.DeleteUser(userName);

            return RedirectToAction("Index");
        }

        public ActionResult LoadUserImage(string userName, HttpPostedFileBase userImageFile)
        {
            if (userImageFile != null)
            {
                Image sourceImage = Image.FromStream(userImageFile.InputStream);
				byte[] bigImage = CreateImage(sourceImage, 120, 150/*to constance*/, false);

                /*
                 * save image by userName
                 */
            }

            return RedirectToAction("Profile", new { userName = userName });
        }

        public FileContentResult GetImage(string userName)
        {
            byte[] image = null /*load image from DB*/;

            return image != null ? File(image, "image/png") : null;
        }

        #region Работа с картинками (надо перенести в проект логики)

        /// <summary> Изменение размера изображения
        /// </summary>
        /// <param name="aSource">Исходное изображение</param>
        /// <param name="aMaxWidth">Ширина</param>
        /// <param name="aMaxHeight">Высота</param>
        /// <param name="aCutBorders">Обрезать края изображения под размеры</param>
        /// <returns>Сжатое изображение</returns>
        private Bitmap ScaleImage(Image aSource, int aMaxWidth, int aMaxHeight, bool aCutBorders)
        {
            // определяем размеры новой картинки
            float imageWidth;
            float imageHeight;
            float top;
            float left;
            float bitmapWidth;
            float bitmapHeight;
            float sourceWidth = aSource.Width;
            float sourceHeight = aSource.Height;

            if (!aCutBorders)
            {
                top = 0;
                left = 0;

                if (sourceWidth <= aMaxWidth && sourceHeight <= aMaxHeight)  // Исходное изображение меньше целевого
                {
                    imageWidth = sourceWidth;
                    imageHeight = sourceHeight;
                }
                else if (sourceWidth / sourceHeight > aMaxWidth / aMaxHeight)  // Пропорции исходного изображения более широкие
                {
                    imageWidth = aMaxWidth;
                    imageHeight = sourceHeight / sourceWidth * aMaxWidth;
                }
                else  // Пропорции исходного изображения более узкие
                {
                    imageWidth = sourceWidth / sourceHeight * aMaxHeight;
                    imageHeight = aMaxHeight;
                }

                bitmapWidth = imageWidth;
                bitmapHeight = imageHeight;
            }
            else
            {
                bitmapWidth = aMaxWidth;
                bitmapHeight = aMaxHeight;

                if (sourceWidth / sourceHeight > aMaxWidth / aMaxHeight)  // Пропорции исходного изображения более широкие
                {
                    imageWidth = sourceWidth / sourceHeight * aMaxHeight;
                    imageHeight = aMaxHeight;
                }
                else  // Пропорции исходного изображения более узкие
                {
                    imageWidth = aMaxWidth;
                    imageHeight = sourceHeight / sourceWidth * aMaxWidth;
                }

                top = (bitmapHeight - imageHeight) / 2;
                left = (bitmapWidth - imageWidth) / 2;
            }

            Bitmap dest = new Bitmap((int)bitmapWidth, (int)bitmapHeight);

            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr.DrawImage(aSource, left, top, imageWidth, imageHeight);
            }

            return dest;
        }

        /// <summary> Преобразование изображения в массив байт
        /// </summary>
        /// <param name="input">Изображение</param>
        /// <returns>Массив байт</returns>
        private byte[] BitmapToByte(Bitmap input)
        {
            MemoryStream ms = new MemoryStream();
            input.Save(ms, ImageFormat.Jpeg);
            byte[] bytearray = ms.ToArray();
            return bytearray;
        }

        /// <summary> Изменение размера изображения
        /// </summary>
        /// <param name="aImage">Исходное изображение</param>
        /// <param name="aMaxWidth">Ширина</param>
        /// <param name="aMaxHeight">Высота</param>
        /// <param name="aCutBorders">Обрезать края изображения под размеры</param>
        /// <returns>Сжатое изображение</returns>
        private byte[] CreateImage(Image aImage, int aMaxWidth, int aMaxHeight, bool aCutBorders)
        {
            Bitmap bitmap = ScaleImage(aImage, aMaxWidth, aMaxHeight, true);
            byte[] imageByte = BitmapToByte(bitmap);
            return imageByte;
        }

        #endregion
    }
}
