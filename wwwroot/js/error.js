// Write your JavaScript code here
const cursor = document.getElementById("cursor");
document.addEventListener('mousemove', (e) => {
    cursor.style.left = e.pageX + 'px'
    cursor.style.top = e.pageY + 'px'
})

