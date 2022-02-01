using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
                                        PizzaService.GetAll();


    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }


    // POST action
    [HttpPost]
    public ActionResult Insert(Pizza pi){
        PizzaService.Add(pi);
        return CreatedAtAction(nameof(Insert), 
        new {id = pi.Id}, pi);
    }
    // PUT action
    [HttpPut("{id}")]
    public ActionResult update(int id, Pizza pi){
        if(id != pi.Id) return BadRequest("No existe");
        
        var exiting = PizzaService.Get(id);
        if(exiting is null) return NotFound();

        PizzaService.Update(pi);
        return NoContent();
    }
    // DELETE action
    [HttpDelete("{id}")]
    public ActionResult Delete(int id){
        if(PizzaService.Get(id) is null) return NotFound();

        PizzaService.Delete(id);
        return NoContent();
    }
}
