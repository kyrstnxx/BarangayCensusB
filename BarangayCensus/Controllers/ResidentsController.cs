using BarangayCensus.Data;
using BarangayCensus.Models;
using BarangayCensus.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class ResidentsController : Controller
{
    private readonly ApplicationDbContext _db;

    public ResidentsController(ApplicationDbContext db)
    {
        _db = db;
    }

    // READ - List all residents
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var residents = await _db.Residents.ToListAsync();
        return View(residents);
    }

    // CREATE - Show Add form
    [HttpGet]
    public IActionResult Add() => View();

    // CREATE - Handle Add form submission
    [HttpPost]
    public async Task<IActionResult> Add(AddResidentViewModel vm)
    {
        var resident = new Resident
        {
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            MiddleName = vm.MiddleName,
            DateOfBirth = vm.DateOfBirth,
            Gender = vm.Gender,
            CivilStatus = vm.CivilStatus,
            Address = vm.Address,
            ContactNumber = vm.ContactNumber,
            Occupation = vm.Occupation,
            IsVoter = vm.IsVoter,
            IsPWD = vm.IsPWD,
            IsSeniorCitizen = vm.IsSeniorCitizen
        };
        await _db.Residents.AddAsync(resident);
        await _db.SaveChangesAsync();
        return RedirectToAction("List");
    }

    // UPDATE - Show Edit form
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var resident = await _db.Residents.FindAsync(id);
        return View(resident);
    }

    // UPDATE - Handle Edit form submission
    [HttpPost]
    public async Task<IActionResult> Edit(Resident vm)
    {
        var r = await _db.Residents.FindAsync(vm.Id);
        if (r != null)
        {
            r.FirstName = vm.FirstName; r.LastName = vm.LastName;
            r.MiddleName = vm.MiddleName; r.DateOfBirth = vm.DateOfBirth;
            r.Gender = vm.Gender; r.CivilStatus = vm.CivilStatus;
            r.Address = vm.Address; r.ContactNumber = vm.ContactNumber;
            r.Occupation = vm.Occupation; r.IsVoter = vm.IsVoter;
            r.IsPWD = vm.IsPWD; r.IsSeniorCitizen = vm.IsSeniorCitizen;
            await _db.SaveChangesAsync();
        }
        return RedirectToAction("List");
    }

    // DELETE
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var r = await _db.Residents.FindAsync(id);
        if (r != null)
        {
            _db.Residents.Remove(r);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction("List");
    }
}
