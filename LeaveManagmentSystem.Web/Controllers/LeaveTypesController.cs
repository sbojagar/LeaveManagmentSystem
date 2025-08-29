using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
using AutoMapper;
using LeaveManagmentSystem.Web.Services;

namespace LeaveManagmentSystem.Web.Controllers
{
    public class LeaveTypesController (ILeaveTypesService _leaveTypesService): Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;
        private const string NameExistsValidationMessage = "This leave type already exists in the database";
       // private readonly ILeaveTypesService _leaveTypesService = leaveTypesService;

        //public LeaveTypesController(ApplicationDbContext context,IMapper mapper)// IMapper injection is for Automapper 
        //{
        //    _context = context;
        //    this._mapper = mapper;// Added mapper
        //}

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            //var data = await _context.LeaveTypes.ToListAsync();
            ////var viewData = data.Select(m => new LeaveTypeReadOnlyVM//IndexVM //Repace this manual mappingwith automapper
            ////{
            ////    Id = m.Id,
            ////    LeaveTypeName = m.LeaveTypeName,
            ////    NumberOfDays = m.NumberOfDays
            ////});
            //var viewDataVM = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            var viewData = await _leaveTypesService.GetAll();
            return View(viewData);
            //return View(await _context.LeaveTypes.ToListAsync());
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Parameterization - key for preventing SQL Injection attacks

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (leaveType == null)
            //{
            //    return NotFound();
            //}
            //var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            //var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);
            //return View(leaveType);
            if(leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)//Overposting by supplying ID parameter ->Create([Bind("Id,LeaveTypeName,NumberOfDays")] LeaveType leaveType)
        {
            // Adding custom validation and model state error
            if (await _leaveTypesService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), "This leave type already exists in the database");
            }
            if (ModelState.IsValid)
            {
                //var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate.LeaveTypeName);
                //_context.Add(leaveType); 
                //await _context.SaveChangesAsync();
                await _leaveTypesService.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,LeaveTypeEditVM leaveTypeEdit) //Edit(int id, [Bind("Id,LeaveTypeName,NumberOfDays")] LeaveType leaveType)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }
            // Adding custom validation and model state error
            if (await _leaveTypesService.CheckIfLeaveTypeNameExistsForEdit(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
                    //_context.Update(leaveType);
                    //await _context.SaveChangesAsync();
                    await _leaveTypesService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException) // Record being updated simultaneously by another person.
                {
                    if (! _leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            //if (leaveType != null)
            //{
            //    _context.LeaveTypes.Remove(leaveType);
            //}

            //await _context.SaveChangesAsync();
            await _leaveTypesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool LeaveTypeExists(int id)
        //{
        //    return _context.LeaveTypes.Any(e => e.Id == id);
        //}       

        //private async Task<bool> CheckIfLeaveTypeNameExists(string name)
        //{
        //    var lowercaseName = name.ToLower();
        //    return await _context.LeaveTypes.AnyAsync(q => q.LeaveTypeName.ToLower().Equals(lowercaseName));
        //}
        //private async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
        //{
        //    var lowercaseName = leaveTypeEdit.Name.ToLower();
        //    return await _context.LeaveTypes.AnyAsync(q => q.LeaveTypeName.ToLower().Equals(lowercaseName)
        //        && q.Id != leaveTypeEdit.Id);
        //}
    }
}
