let colorCircles = document.querySelectorAll(".color-circle");
colorCircles.forEach((circle) => {
 circle.addEventListener("click", selectColor, false);
});

function selectColor(event) {
 // Remove the 'selected' class from all circles
 colorCircles.forEach((circle) => {
   circle.classList.remove("selected");
 });

 // Add the 'selected' class to the clicked circle
 event.target.classList.add("selected");
}
