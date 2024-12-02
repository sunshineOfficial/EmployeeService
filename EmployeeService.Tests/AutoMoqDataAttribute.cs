using AutoFixture;
using AutoFixture.AutoMoq;

namespace EmployeeService.Tests;

public class AutoMoqDataAttribute() : AutoDataAttribute(() => new Fixture().Customize(new AutoMoqCustomization()));