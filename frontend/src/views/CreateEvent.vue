<template>
  
  <div class="create-event-container">

    <div class="wrapper">
      <h3>Create new event</h3>
      <form action="">
        <p>
          <label for="">Event name</label>
          <input type="text">
        </p>
        <p>
          <label for="">Location</label>
          <input type="text">
        </p>

        <p>
          <label for="">Time</label>
          <input type="time">
        </p>

         <p>
          <label for="">Date</label>
          <input type="date">
        </p>

         <p>
          <label for="">Description</label>
           <textarea name="" id="" cols="30" rows="7"></textarea>
        </p>

        <p class="input-file-wrapper">
          <label for="upload">Upload your photo</label>
          <input type="file" name="" id="upload">
        </p>
        <p>
          <button>Create</button>
        </p>
      </form>
    </div>

    
</div>



</template>

<script>
export default {

  name: "CreateEvent",
  components: {},

  

  data() {
    return {};
  },

}
</script>

<style scoped>

* {
  box-sizing: border-box;
}

body {
  padding-top: 1rem;
}

.wrapper {
  max-width: 700px;
  margin: 0 auto;
  padding: 1em;
  background: #f9f9f9;
  border: 1px solid #c1c1c1;
}

h3 {
  margin: 0;
}

input:focus,
textarea:focus {
  outline: 3px solid gold;
}

input,
textarea,
button {
  width: 100%;
  border: 1px solid #000;
}

.wrapper > * {
  padding: 1em;
}

form label {
  display: block;
}

form p {
  margin: 0;
}

button,
input,
textarea {
  padding: 1em;
}

button {
  background: lightgrey;
  width: 100%;
  border: 0;
}
button:hover, button:focus {
  background: gold;
  outline: 0;
}

form {
  display: grid;
  grid-template-columns: 2fr 1fr;
  grid-gap: 20px;
}
form p {
  grid-column: 1 / 2;
}

.input-file-wrapper {
  grid-column: 2 / 3;
  grid-row: 1 / 2;
}


  


</style>