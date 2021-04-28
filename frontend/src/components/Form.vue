<template>
  <div class="wrapper">
      <h3>Create new event</h3>
      <form action="">
        <p>

          <label id="eventName" for="">Event name</label>
          <input type="text" v-model="eventName">
        </p>
        <p>
          <label id="location" for="">Location</label>
          <input type="text" v-model="location">
        </p>

        <p>
          <label id="time1" for="">Start Time</label>
          <input type="time" id="time">
        </p>

        <p>
          <label id="time2" for="">End Time</label>
          <input type="time" id="time"> 
        </p>

         <p>
          <label id="date1" for="">Start Date</label>
          <input type="date">
        </p>
        <p>
          <label id="date2" for="">End Date</label>
          <input type="date" >
        </p>

         <p>
          <label id="description" for="">Description</label>
           <textarea v-model="description" name="" id="" cols="30" rows="7"> </textarea>
        </p>

       <p class="checkbox">
       
         
        <label for="public">Public</label>
         
      <img class="door" src="../assets/door.png">

        <input id="public" value="Public" type="checkbox" v-model="publicAccess"  @change="disablePrivate" >
               
        <label for="private">Private</label>
        <img class="lock" src="../assets/lock.png">
        <input  id="private" value="Private" type="checkbox" v-model="privateAccess" @change="disablePublic">
    
          </p>


        <p class="input-file-wrapper">
          <label for="upload">Upload your photo</label>
          <input type="file" name="" id="upload">
        </p>
        
        <p>
          <button @click.prevent="postEvent">Create</button>
        </p>
      </form>
    </div>
</template>

<script>
  
export default {
  data() {
    return {
      eventName: '',
      location: '',
      startDateTime: '2021-04-20T13:31:59.3528866Z',
      endDateTime: '2022-04-20T13:31:49.3528866Z',
      description: '',
      publicAccess: true,
      privateAccess: false,
      access: "",
      hostId:"061eb70c-7055-4d07-a584-b3c20cd59d73"
     
    }
  },
  methods: {
    postEvent() {

      if(this.publicAccess) {
        this.access = 'public'
      } 
      else if(this.privateAccess) {
        this.access = 'private' 
      } 
      // Vuex
      console.log({ eventName: this.eventName, location: this.location, startDateTime: this.startDateTime, endDateTime: this.endDateTime,
     description: this.description, access: this.access, hostId: this.hostId});

       console.log(typeof this.eventName);
      console.log(typeof this.location);
      console.log(typeof this.description);
      console.log(typeof this.access);


  
    

     //this.$store.commit("setName", this.eventName)
     this.$store.commit("setMyEvent",  {
          name: this.eventName,
          description: this.description,
          access: this.access,
          location: this.location,
          startDateTime: "2021-04-20T13:31:59.3528866+00:00",
          endDateTime: "2022-04-21T13:31:49.3528866+00:00",
          hostId: "7bcd7cff-1848-4a02-9db9-3d2265e97aba",
        },)
   // this.$store.dispatch("createNewEvent", this.eventName, this.location, this.startDateTime, this.endDateTime, this.description, this.hostId, this.access)
   this.$store.dispatch("createNewEvent")

    

    },

    onChangeMethod() {
      console.log(this.privateAccess);
    },
   disablePublic(){
     this.publicAccess=false;
   },
   disablePrivate(){
     this.privateAccess=false;
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