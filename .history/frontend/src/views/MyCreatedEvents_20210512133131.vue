<template>
  <div class="myCreated-Events-container">


<div class="test">
  <v-col
          cols="12"
          sm="18"
        >
          <v-select
            v-model="value"
            :items="items"
           filled
            chips
           
            multiple
            @change="filterEvents"
          ></v-select>
        </v-col>
</div>

     <div class="event-list" >
      <EventItem v-for="event of events" :key="event.id" :event="event" />
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
    async filterEvents() {
  

     
    }
  },
 


}
</script>

<style scoped>

</style>