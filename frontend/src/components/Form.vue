<template>
  <div class="wrapper">
      <h3>Create new event</h3>
      <div class="alert alert-success" v-if="isSuccess">Event was Created Successfully</div>
      <form @submit.prevent="onCreateEvent">
        <p>

          <label id="eventName" for="">Event name</label>
          <input type="text" v-model="eventName" />
        </p>
        <p>
          <label id="location" for="">Location</label>
          <input type="text" v-model="location">
        </p>

        <p>
          <label id="time1" for="">Start Time</label>
          <input type="time" id="time" v-model="startTime">
        </p>

        <p>
          <label id="time2" for="">End Time</label>
          <input type="time" id="time" v-model="endTime"> 
        </p>

         <p>
          <label id="date1" for="">Start Date</label>
          <input type="date" v-model="startDate">
        </p>
        <p>
          <label id="date2" for="">End Date</label>
          <input type="date" v-model="endDate">
        </p>

         <p>
          <label id="description" for="">Description</label>
           <textarea v-model="description" name="" id="" cols="30" rows="7"> </textarea>
        </p>

       <p class="checkbox">
       
         
        <label for="public">Public</label>
         
      <img class="door" src="../assets/door.png">

        <input id="public" value="Public" type="checkbox" v-model="publicAccess"  >
               
        <label for="private">Private</label>
        <img class="lock" src="../assets/lock.png">
        <input  id="private" value="Private" type="checkbox" v-model="privateAccess" >
    
          </p>


        <p class="input-file-wrapper">
          <label for="upload">Upload your photo</label>
          <input type="file" name="" id="upload">
        </p>
        
        <p>
          <button type="submit" class="btn btn-primary">Create</button>
        </p>
      </form>
    </div>
</template>

<script>
  import axios from 'axios';
export default {
  data() {
    return {
      eventName: '',
      location: '',
      startTime: '',
      endTime: '',
      startDate: '',
      endDate: '',
      description: '',
     publicAccess: true,
      privateAccess: false,
      access: "",
      isSuccess: false
     
    }
  },
  methods: {
    onCreateEvent() {

            if(this.publicAccess) {
        this.access = 'public'
      } 
      else if(this.privateAccess) {
        this.access = 'private' 
      }


      axios.post('https://geshdo-events-dev-default-rtdb.europe-west1.firebasedatabase.app/events.json',
      {eventName: this.eventName, location: this.location, 
      startTime: this.startTime, endTime: this.endTime, startDate: this.startDate, endDate: this.endDate,
      description: this.description, access: this.access},
      ).then(response => {
        this.isSuccess = true;
        console.log(response);
      });
    }

  },
  
  }
</script>

<style scoped>



* {
  box-sizing: border-box;
  font-family:  "Montserrat", sans-serif;;
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
  outline: 3px solid rgba(107, 21, 206, 0.233);
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
  background: rgba(107, 21, 206, 0.548);
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


.checkbox {
  display: flex;
  flex-direction: row;
  justify-content: center; 
  align-items: center;
  
}


#public, #private {
  cursor: pointer;
  outline: none;
  margin-right: 5vw;

}



.door {
  width: 10%;

}

.lock {
  width: 10%;


}

</style>