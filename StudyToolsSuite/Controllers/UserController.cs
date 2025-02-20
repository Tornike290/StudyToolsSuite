using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyToolsSuite.Models;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")] // Only Admins can manage users
public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /User/
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        return View(users);
    }

    // GET: /User/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
            return NotFound();

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();

        return View(user);
    }

    // POST: /User/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(string id, ApplicationUser user)
    {
        if (id != user.Id)
            return NotFound();

        var existingUser = await _userManager.FindByIdAsync(id);
        if (existingUser == null)
            return NotFound();

        existingUser.FirstName = user.FirstName;
        existingUser.FullName = user.FullName;
        existingUser.Email = user.Email;
        existingUser.UpdatedAt = DateTime.UtcNow;

        var result = await _userManager.UpdateAsync(existingUser);
        if (result.Succeeded)
            return RedirectToAction(nameof(Index));

        return View(user);
    }

    // GET: /User/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
            return NotFound();

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return NotFound();

        return View(user);
    }

    // POST: /User/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction(nameof(Index));
    }
}