async function hello() {
    const res = await fetch('/api/hello');
    const data = await res.json();
    document.getElementById('out').textContent = JSON.stringify(data, null, 2);

}
document.getElementById("helloBtn").addEventListener("click", hello);