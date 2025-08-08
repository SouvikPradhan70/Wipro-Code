// Task 1: Fetch employee data and log it
fetch("https://dummy.restapiexample.com/api/v1/employees")
  .then(response => {
    if (!response.ok) {
      throw new Error("Network response was not OK");
    }
    return response.json();
  })
  .then(data => {
    console.log("Employee Data:", data);
  })
  .catch(error => {
    console.error("Error fetching data:", error);
  });
