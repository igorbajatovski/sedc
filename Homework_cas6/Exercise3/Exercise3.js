window.addEventListener("resize", function(event)
{
   let innerPageSize = this.document.getElementById("InnerPageSize");
   innerPageSize.textContent = `Inner Page size is = Width: ${event.target.innerWidth}, Height: ${event.target.innerHeight}`;

   let outerPageSize = this.document.getElementById("OuterPageSize");
   outerPageSize.textContent = `Outer Page size is = Width: ${event.target.outerWidth}, Height: ${event.target.outerHeight}`;

   let screenSize = this.document.getElementById("ScreenSize");
   screenSize.textContent = `Screen size is = Width: ${event.target.screen.width}, Height: ${event.target.screen.height}`;
})