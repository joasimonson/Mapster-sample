﻿namespace MapsterSample;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public Address Address { get; set; } = null!;
}
