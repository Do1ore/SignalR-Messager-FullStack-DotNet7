﻿using System.Net.Http.Headers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//namespace Api.Api.Controllers
//{
//     [Route("api/[controller]")]
//     [ApiController]
//     public class AccountController : ControllerBase
//     {
//         private readonly IUserService _userService;
//         private readonly ILegacyChatRepository _legacyChatRepository;
//         private readonly IPathMaster _pathMaster;
//         private readonly IProfileImageService _userProfileImage;
//         
//
//
//         public AccountController(IPathMaster pathMaster, IUserService userService, AppDbContext db,
//             IProfileImageService userProfileImage, ILegacyChatRepository legacyChatRepository)
//         {
//             _pathMaster = pathMaster;
//             _userService = userService;
//             _userProfileImage = userProfileImage;
//             _db = db;
//             _legacyChatRepository = legacyChatRepository;
//         }
//
//
//         [HttpPost("upload"), DisableRequestSizeLimit]
//         public async Task<IActionResult> UploadAsync()
//         {
//             string userId = _userService.GetMyId();
//             string a = _userService.GetMyName();
//             AppUser? user = await _db.Users
//                 .Include(appUser => appUser.UserProfileImages)
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(i => i.Id.ToString() == userId);
//             if (user == null)
//             {
//                 return Unauthorized("User not found");
//             }
//
//
//             IFormFile file = Request.Form.Files[0];
//             string folderName = Path.Combine("Resourses", "Uploaded");
//             string pathToSave = Path.Combine(Directory.GetCurrentDirectory());
//
//             if (file.Length > 0)
//             {
//                 string filename = Guid.NewGuid().ToString()
//                                   + DateTime.Now.ToShortDateString()
//                                   + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName!.Trim('"');
//
//                 string fullPath = Path.Combine(pathToSave, folderName, filename);
//                 string relativePath = Path.Combine(folderName, filename);
//
//                 using (FileStream stream = new(fullPath, FileMode.Create))
//                 {
//                     file.CopyTo(stream);
//                 }
//
//                 var profileImage =
//                     _userProfileImage.CreateProfileImageModel(filename, relativePath, userId);
//
//                 _ = await _db.ProfileImages.AddAsync(profileImage);
//                 _ = await _db.ProfileImageStorages.AddAsync(new UserProfileImageStorage()
//                 {
//                     UserId = Guid.Parse(userId),
//                     ProfileImage = profileImage
//                 });
//                 _ = await _db.SaveChangesAsync();
//                 await _legacyChatRepository.UpdateCurrentProfileImage(profileImage.ImageId.ToString(), userId);
//
//                 return Ok(new JsonResult("Uploaded"));
//             }
//             else
//             {
//                 return BadRequest();
//             }
//         }
//
//         [HttpGet("profile-image")]
//         public async Task<IActionResult> GetProfileImage()
//         {
//             string userId = _userService.GetMyId();
//             string a = _userService.GetMyName();
//             AppUser? user = await _db.Users
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(i => i.Id.ToString() == userId);
//             if (user == null)
//             {
//                 return Unauthorized("User not found");
//             }
//
//             string imagePath = await _legacyChatRepository.GetProfileImage(userId);
//             if (string.IsNullOrEmpty(imagePath))
//             {
//                 return BadRequest("No image found.");
//             }
//
//             string pathToImage = Path.Combine(Directory.GetCurrentDirectory(), imagePath);
//             if (!System.IO.File.Exists(pathToImage))
//             {
//                 return BadRequest("No image file found.");
//             }
//
//             byte[] file = System.IO.File.ReadAllBytes(pathToImage);
//             Response.Headers.Add("Content-Type", "image/png");
//
//             return File(file, "image/png");
//         }
//
//         [HttpPost("profile-image-by-id")]
//         public async Task<FileContentResult> GetProfileImageById([FromBody] UserIdModel userIdModel)
//         {
//             AppUser? user = await _db.Users
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(i => i.Id.ToString() == userIdModel.userId);
//             if (user == null)
//             {
//             }
//
//             string imagePath = await _legacyChatRepository.GetProfileImage(userIdModel.userId);
//             if (string.IsNullOrEmpty(imagePath))
//             {
//             }
//
//             string pathToImage = Path.Combine(Directory.GetCurrentDirectory(), imagePath);
//             if (!System.IO.File.Exists(pathToImage))
//             {
//             }
//
//             byte[] file = await System.IO.File.ReadAllBytesAsync(pathToImage);
//             string extension = Path.GetExtension(pathToImage);
//
//             Response.Headers.Add("Content-Type", GetMimeType(extension));
//             Response.StatusCode = 200;
//             return File(file, GetMimeType(extension));
//         }
//
//         public class UserIdModel
//         {
//             public required string userId { get; set; }
//         }
//
//         [HttpPost("search-user")]
//         public async Task<IActionResult> SearchUser([FromBody] SearchUserModel searchUserModel)
//         {
//             var users = await _legacyChatRepository.SearchUsers(searchUserModel.SearchTerm);
//             return users == null || users.Count < 0 ? BadRequest("No users found") : Ok(users);
//         }
//
//         public class SearchUserModel
//         {
//             public required string SearchTerm { get; set; }
//         }
//
//         private string GetMimeType(string fileExtension)
//         {
//             return fileExtension.ToLower() switch
//             {
//                 ".jpg" or ".jpeg" => "image/jpeg",
//                 ".png" => "image/png",
//                 _ => "application/octet-stream",
//             };
//         }
//     }
// }