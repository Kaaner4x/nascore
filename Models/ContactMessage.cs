using System;

namespace Nascore.Models;

public class ContactMessage
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public string? Email { get; set; } 
    public string Phone { get; set; } = string.Empty;
    public string? Subject { get; set; } 
    public string? Message { get; set; } 
    public bool IsKvkkAccepted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
