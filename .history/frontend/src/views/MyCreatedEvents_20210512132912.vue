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
      items: ['Show all events', 'Show only my events'],
      value: ['Show only my events'],
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
       console.log(this.value);

       if(this.value.includes("Show only my events")) {
         await this.$store.dispatch("fetchFilteredEvents", this.value)
       }
    }
  },
  async created() {
    this.$store.commit("setAccessTypes", this.value)
    await this.$store.dispatch("fetchFilteredEvents", this.value);
  },


}
</script>

<style scoped>

</style>