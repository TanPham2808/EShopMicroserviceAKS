

namespace EShop.Core.DTO;

public record AuthenticationResponse(
      Guid UserID,
      string? Email,
      string? PersonName,
      string? Gender,
      string? Token,
      bool Success
  )
{
    // Khởi tạo constructor không tham số
    public AuthenticationResponse() : this(Guid.Empty, null, null, null, null, false)
    {
    }
}

