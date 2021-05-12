<template>
  <div class="myCreated-Events-container">

     <div  class="event-list" >
      <EventItem v-show="ifHost" v-for="event of events" :key="event.id" :event="event" />
    </div>

  </div>
</template>

<script>
import EventItem from "../components/EventItem.vue";

export default {

  data() {
    return {
      myEvents: [],

    }
  },
  components: {
    EventItem,
  },

  computed: {
     events(){
       return this.$store.state.events;
     },
     
    

    
},

  methods: {
     
  },
 


}
</script>

<style scoped>

</style>