<template>
  <div class="login">
    <h1>Login</h1>
    <hr>
    <b-form @submit="onSubmit" v-if="show">
        <b-form-row>
          <b-col></b-col>
          <b-col>
        <b-form-input
          id="iUsername"
          v-model="form.username"
          type="text"
          required
          placeholder="Username"
        ></b-form-input>
        <b-form-text id="password-help-block">admin</b-form-text>
      </b-col>
      <b-col></b-col>
        </b-form-row>
      <b-form-row>
        <b-col></b-col>
        <b-col> 
          <b-form-input type="password" id="iPassword" v-model="form.password" aria-describedby="password-help-block" placeholder="Password"></b-form-input>
          <b-form-text id="password-help-block">admin</b-form-text></b-col>
      <b-col> </b-col>
      </b-form-row>
     
     

       <b-button type="submit" variant="primary">Login</b-button>
    </b-form>
  </div>
</template>

<script>
  export default {
    name: "Login",
    data() {
      return {
        form: {
          username: '',
          password: ''
        },
        show: true
      }
    },
    methods: {
      onSubmit(evt) {
        evt.preventDefault()
        this.$store.dispatch('login', this.form).then(() => this.$router.push('/'))
       .catch(err => console.log(err))
      }
    }
  }
</script>