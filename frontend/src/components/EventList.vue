<template>
  <div class="wrapper">
   
     <div class="filter-wrapper">
        
      
        <v-col
          cols="12"
          sm="18"
        >
          <v-select
            v-model="value"
            :items="items"
            attach
            chips
            label="Filter"
            multiple
            @change="filterEvents"
          ></v-select>
        </v-col>
       
    </div>
        
    <div class="event-list">
      <EventItem v-for="event of events" :key="event.id" :event="event" />
    </div>
  </div>
</template>

<script>
import EventItem from "./EventItem.vue";
export default {
  data(){
    return{
      items: ['private', 'public'],
      value: ['public'],
     
    }
    
  },
  methods:{
  async  filterEvents(){
    console.log(this.value);
    await this.$store.dispatch("fetchFilteredEvents", this.value)
    }
  },
  components: {
    EventItem,
  },
  computed: {
     events(){
       return this.$store.state.events
     }
  },
  async created() {
    this.$store.commit("setAccessTypes", this.value)
    await this.$store.dispatch("fetchFilteredEvents", this.value);
  },
};
</script>

<style scoped>
.wrapper {
  width: 100%;

  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.event-list {
  width: 95%;
  padding-top: 3vw;
  display: grid;
  grid-template-columns: repeat(3, 1fr);

  justify-content: center;

  position: relative;
}


.filter-wrapper{


 padding: 0 1vw 0 1vw;
 margin-top:2vh;
 
 color:white !important;
 align-self: flex-end;
 margin-right:6vw;
}

.col-sm-12 {
  font-weight: bold;
  color:white;
  border-radius: 10px;
}



</style>
