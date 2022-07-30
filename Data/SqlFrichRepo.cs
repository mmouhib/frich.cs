﻿using frich.Entities;
using frich.Data.Interfaces;

namespace frich.Data;

public class SqlFrichRepo : IPersonRepo
{
    private readonly FrichDbContext _context;

    public SqlFrichRepo(FrichDbContext context)
    {
        _context = context;
    }

    public bool SaveMigrations()
    {
        return _context.SaveChanges() >= 0;
    }

    public IEnumerable<Person> GetAll()
    {
        return _context.Persons.ToList();
    }

    public Person GetById(int id)
    {
        return _context.Persons.FirstOrDefault(person => person.PersonId == id);
    }

    public void Add(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));

        _context.Add(person);
    }

    public void Delete(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));

        _context.Persons.Remove(person);
    }

    public void Update(Person person)
    {
        // optional (method needs no implementation,
        // it is available only to follow conventions
    }
}