<template>
 
     <v-dialog
    v-model="openGuest"
        max-width="500px"
    >
          <!---  <v-card width="500px" class="mt-5 mx-a">
          <v-card-title class="pb-0">
          Join as Guest
             </v-card-title>
            <v-card-text>
              <v-form @submit.prevent="joinEvent">
                <v-text-field
                  id="userName"
                  
                  label="Username"
                  prepend-icon="mdi-account-circle"
                />
                  </v-form>
                </v-card-text>
                <v-card-actions>
                  <v-btn class="join-btn" type="submit">JOIN</v-btn>
                </v-card-actions>
            
            
            <v-divider></v-divider>
         

          <v-card-title class="pb-0">
            <h2 class="join-as-guest">OR</h2>
            <v-card-text> </v-card-text>
            <v-divider></v-divider>
          </v-card-title>

          <v-card-actions>
            <v-btn
              class="login"
              type="submit"
              :color="type === 'guest' ? 'secondary' : '#9933FF'"
              >Login</v-btn
            >
            <div class="error" v-if="error">{{ error.message }}</div>
          </v-card-actions>
        </v-card>-->
    </v-dialog>
   
</template>

<script>
export default {
  data() {
    return {
       openGuest:true
    };
  },
  methods: {
  joinEvent() {
      console.log('joining event as guest');
    },
  },
};
</script>

<style scoped>


.join-as-guest {
  margin-left: auto;
  margin-right: auto;
}

.login {
  width: 30%;
  margin-left: auto;
  margin-right: auto;
}

.join-btn {
  margin-left: auto;
  margin-right: auto;
}
</style>
