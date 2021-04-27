<template>
  <div class="event-card" @click="redirect">
    <v-card :loading="loading" class="mx-auto my-12" max-width="374">
      <div class="access">
        <p>Public</p>
       
      </div>
      <v-img class="event-img" height="200px" :src="event.imgUrl">
      
        <v-card-title>
          <p>{{ event.name }}</p>
        </v-card-title>
      </v-img>
    </v-card>
  </div>
</template>

<script>
export default {
  props: ["event"],

  

  methods: {
    redirect() {
      this.$router.push("/details/" + this.event.id);
    },
  },

  
};
</script>

<style scoped>
.event-card {
  text-align: center;
  padding: 1vw;
  height: 75%;

  display: flex;
  align-items: center;
  transition: transform 0.2s;

}

.v-sheet.v-card {
  border-radius: 0px;
   box-shadow: 5px 10px black;
}

.event-card:hover {
  cursor: pointer;
  transform: scale(1.1);
}

.v-card__title {
  justify-content: center;
  margin-top: 4vw;
  color: white;
  font-size:1.5vw;
}

.access {
  background-color: white;
  height: 20px;
}

.event-img {
  text-align: center;
  width:30vw;
  
}
</style>
