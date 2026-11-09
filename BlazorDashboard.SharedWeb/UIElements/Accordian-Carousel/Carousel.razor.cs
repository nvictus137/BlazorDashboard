using System.Collections.Generic;

namespace BlazorDashboard.SharedWeb.UIElements;

public class CarouselItem
{
    public string Image { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;

    public string Link { get; set; } = "javascript:void(0)";
}

public class CarouselItemCollection : List<CarouselItem>
{

}

public partial class Carousel
{
}
