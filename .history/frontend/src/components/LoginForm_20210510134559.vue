<template>
  
  <div class="form-grid-container">
   
    <v-app>
<div class="grid">
       <v-card width="500px" class="mt-5 mx-a">
         <v-card-title class="pb-0">
        <h1>Login</h1>
         </v-card-title>
         <v-card-text>
         <v-form>
           <v-text-field 
           
           label="Email" 
           prepend-icon="mdi-account-circle"

            v-model="email"
           />
           <v-text-field
           :type="showPassword ? 'text' : 'password'"
           label="Password"
           prepend-icon="mdi-lock"
           :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
           @click:append="showPassword = !showPassword"
           v-model="password"
           />
         </v-form>
         </v-card-text>
         <v-divider></v-divider>
         <v-card-actions>
         <v-btn :color="type==='guest' ? 'secondary' : '#a64dff'">Register</v-btn>
         <v-spacer></v-spacer>
         <v-btn type="submit" :color="type==='guest' ? 'secondary' : '#9933FF'" @click="login">Login</v-btn>
         <div class="error" v-if="error">{{error.message}}</div>
        
         </v-card-actions>
    </v-card>
</div>
  </v-app>
    </div>
       

</template>

<script>


export default {

  name: "LoginForm",
  data() {
    return {
      showPassword: false,
      email: '',
      password: '',
      error: ''
    }
  },
  methods: {
    async login() {
      let loginCredentials={
        email:this.email,
        password:this.password
      }
   // await this.$store.dispatch("login", loginCredentials)
   await this.$store.dispatch("getRegistration", getReg)
    
    this.$router.push("/")


    }
  }
  
}

</script>



<style scoped>

.grid {
 
display: grid;
  justify-items: center;
  align-items: center;
 grid-template-columns: 1fr;
  grid-template-rows: 70vh;


}







</style>