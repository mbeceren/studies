<template>
  <div>
    <b-form @submit="onSubmit">
      <b-form-group id="input-group-1" label="Title" label-for="input-1">
        <b-form-input
          id="input-1"
          v-model="form.title"
          type="text"
          required
          placeholder="Enter Title"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Location" label-for="input-2">
        <b-form-input id="input-2" v-model="form.location" required placeholder="Enter Location"></b-form-input>
      </b-form-group>
         <label for="example-datepicker">Choose a date</label>
        <b-form-datepicker id="example-datepicker" v-model="form.date" class="mb-2"></b-form-datepicker>
        <p>Value: '{{ form.date }}'</p>
      <b-button type="submit" variant="primary">Add</b-button>
    </b-form>
  </div>
</template>

<script>
import axios from '../plugins/axios'
export default {
  name: "AddAppointment",
  data() {
    return {
      form: {
        title: "",
        location: "",
        date: null
      }
    };
  },
  methods: {
    onSubmit(e) {
        e.preventDefault();
        axios.post(axios.defaults.baseURL + "/appointment-add", this.form).then(() => {
            return this.$router.push("appointments");
        });
    }
  }
};
</script>