<template>
  <div class="home">
    <div class="numberCounter">
      <p>{{$store.getters.getAllEvents}}</p>
      
      <button v-on:click="getEvents">Fetch all events</button>
      
      
    </div>

    <div class="specEvent">
      <p>{{$store.state.specEvent.location}}</p>
      <button v-on:click="getSpecEvent">Fetch specific event</button>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src


export default {
  name: 'Home',
  components: {

  },

  data(){

    return{
      
    }
      
         
       
  },
  

  methods:
  {
    getEvents(){
      
       return this.$store.dispatch('fetchEvents')
    },

    getSpecEvent(){
      return this.$store.dispatch('fetchSpecEvent')
    }
  }
  
}
</script>

<style scoped>
 .home{
   width:100%;
   height:100vh;
   background-color:pink;
   position: relative;
 }

 .numberCounter, .specEvent{
    width: 640px; /* Can be in percentage also. */
    height: 50%;
    margin: 0 auto;
    padding: 10px;
    position: relative;
   background-color: white;
   
 }
</style>
