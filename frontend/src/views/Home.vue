<template>
  <div class="home">
    <div class="event-list-wrapper">
     <EventList/>
    </div>
  </div>
</template>

<script>
import EventList from '../components/EventList.vue'


export default {
  name: 'Home',
  components: {
   EventList
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
    },
    
  }
  
}
</script>

<style scoped>

  .home {

    width: 100%;
    height: 100vh;
     background-image: radial-gradient(at top left, black, transparent),
    radial-gradient(at top right, rgb(81, 3, 145), transparent),
    radial-gradient(at bottom left, #4110d4, transparent);


  }
 
</style>
